using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;

namespace ApiProject.Controllers;

public class CategoriesCatalogController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoriesCatalogController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriesCatalog>>> Get()
    {
        var categoriesCatalog = await _unitOfWork.CategoriesCatalog.GetAllAsync();
        return Ok(categoriesCatalog);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var categoriesCatalog = await _unitOfWork.CategoriesCatalog.GetByIdAsync(id);
        if (categoriesCatalog == null)
        {
            return NotFound($"Categories Catalog with id {id} was not found.");
        }
        return Ok(categoriesCatalog);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriesCatalog>> Post(CategoriesCatalog categoriesCatalog)
    {
        _unitOfWork.CategoriesCatalog.Add(categoriesCatalog);
        await _unitOfWork.SaveAsync();
        if (categoriesCatalog == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = categoriesCatalog.Id }, categoriesCatalog);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoriesCatalog categoriesCatalog)
    {
        // Validación: objeto nulo
        if (categoriesCatalog == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != categoriesCatalog.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingCategoryCatalog = await _unitOfWork.CategoriesCatalog.GetByIdAsync(id);
        if (existingCategoryCatalog == null)
            return NotFound($"No se encontró la categoría con ID {id}.");

        // Actualización controlada de campos específicos
        existingCategoryCatalog.Name = categoriesCatalog.Name;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.CategoriesCatalog.Update(existingCategoryCatalog);
        await _unitOfWork.SaveAsync();

        return Ok(existingCategoryCatalog);
    }

    //DELETE: api/CategoriesCatalog
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
    var categoriesCatalog = await _unitOfWork.CategoriesCatalog.GetByIdAsync(id);
    if (categoriesCatalog == null)
        return NotFound();

    _unitOfWork.CategoriesCatalog.Remove(categoriesCatalog);
    await _unitOfWork.SaveAsync();

    return NoContent();
    }
}
