using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;

namespace ApiProject.Controllers;

public class SurveysController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public SurveysController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Surveys>>> Get()
    {
        var surveys = await _unitOfWork.Surveys.GetAllAsync();
        return Ok(surveys);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var surveys = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (surveys == null)
        {
            return NotFound($"Surveys with id {id} was not found.");
        }
        return Ok(surveys);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Surveys>> Post(Surveys surveys)
    {
        _unitOfWork.Surveys.Add(surveys);
        await _unitOfWork.SaveAsync();
        if (surveys == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = surveys.Id }, surveys);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Surveys surveys)
    {
        // Validación: objeto nulo
        if (surveys == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != surveys.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingSurveys = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (existingSurveys == null)
            return NotFound($"No se encontró la respuesta de opciones con ID {id}.");

        // Actualización controlada de campos específicos
        existingSurveys.Name = surveys.Name;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.Surveys.Update(existingSurveys);
        await _unitOfWork.SaveAsync();

        return Ok(existingSurveys);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
    var surveys = await _unitOfWork.Surveys.GetByIdAsync(id);
    if (surveys == null)
        return NotFound();

    _unitOfWork.Surveys.Remove(surveys);
    await _unitOfWork.SaveAsync();

    return NoContent();
    }
}
