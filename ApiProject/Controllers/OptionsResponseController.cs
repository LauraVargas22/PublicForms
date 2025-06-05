using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;

namespace ApiProject.Controllers;

public class OptionsResponseController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public OptionsResponseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OptionsResponse>>> Get()
    {
        var optionsResponses = await _unitOfWork.OptionsResponse.GetAllAsync();
        return Ok(optionsResponses);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var optionsResponse = await _unitOfWork.OptionsResponse.GetByIdAsync(id);
        if (optionsResponse == null)
        {
            return NotFound($"Options Response with id {id} was not found.");
        }
        return Ok(optionsResponse);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionsResponse>> Post(OptionsResponse optionsResponse)
    {
        _unitOfWork.OptionsResponse.Add(optionsResponse);
        await _unitOfWork.SaveAsync();
        if (optionsResponse == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = optionsResponse.Id }, optionsResponse);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] OptionsResponse optionsResponse)
    {
        // Validación: objeto nulo
        if (optionsResponse == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != optionsResponse.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingOptionsResponse = await _unitOfWork.OptionsResponse.GetByIdAsync(id);
        if (existingOptionsResponse == null)
            return NotFound($"No se encontró la respuesta de opciones con ID {id}.");

        // Actualización controlada de campos específicos
        existingOptionsResponse.OptionText = optionsResponse.OptionText;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.OptionsResponse.Update(existingOptionsResponse);
        await _unitOfWork.SaveAsync();

        return Ok(existingOptionsResponse);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
    var optionsResponse = await _unitOfWork.OptionsResponse.GetByIdAsync(id);
    if (optionsResponse == null)
        return NotFound();

    _unitOfWork.OptionsResponse.Remove(optionsResponse);
    await _unitOfWork.SaveAsync();

    return NoContent();
    }
}
