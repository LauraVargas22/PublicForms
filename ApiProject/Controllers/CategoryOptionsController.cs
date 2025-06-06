using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;

namespace ApiProject.Controllers;

public class CategoryOptionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryOptionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryOptions>>> Get()
    {
        var categoryOptions = await _unitOfWork.CategoryOptions.GetAllAsync();
        return Ok(categoryOptions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var categoryOption = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
        if (categoryOption == null)
        {
            return NotFound($"Category Option with id {id} was not found.");
        }
        return Ok(categoryOption);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryOptions>> Post(CategoryOptions categoryOption)
    {
        _unitOfWork.CategoryOptions.Add(categoryOption);
        await _unitOfWork.SaveAsync();
        if (categoryOption == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = categoryOption.Id }, categoryOption);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoryOptions categoryOptions)
    {
        // Validación: objeto nulo
        if (categoryOptions == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != categoryOptions.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingCategoryOptions = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
        if (existingCategoryOptions == null)
            return NotFound($"No se encontró la categoría con ID {id}.");

        // Actualización controlada de campos específicos
        existingCategoryOptions.OptionsResponseId = categoryOptions.OptionsResponseId;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.CategoryOptions.Update(existingCategoryOptions);
        await _unitOfWork.SaveAsync();

        return Ok(existingCategoryOptions);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
    var categoryOptions = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
    if (categoryOptions == null)
        return NotFound();

    _unitOfWork.CategoryOptions.Remove(categoryOptions);
    await _unitOfWork.SaveAsync();

    return NoContent();
    }
}
