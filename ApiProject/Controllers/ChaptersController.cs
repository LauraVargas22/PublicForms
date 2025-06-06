using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;

namespace ApiProject.Controllers
{
    public class ChaptersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChaptersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Chapters>>> Get()
        {
            var chapters = await _unitOfWork.Chapters.GetAllAsync();
            return Ok(chapters);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var chapters = await _unitOfWork.Chapters.GetByIdAsync(id);
            if (chapters == null)
            {
                return NotFound($"Chapters with id {id} was not found.");
            }
            return Ok(chapters);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Chapters>> Post(Chapters chapters)
        {
            _unitOfWork.Chapters.Add(chapters);
            await _unitOfWork.SaveAsync();
            if (chapters == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = chapters.Id }, chapters);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] Chapters chapters)
        {
            // Validación: objeto nulo
            if (chapters == null)
                return BadRequest("El cuerpo de la solicitud está vacío.");

            // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
            if (id != chapters.Id)
                return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

            // Verificación: el recurso debe existir antes de actualizar
            var existingChapters = await _unitOfWork.Chapters.GetByIdAsync(id);
            if (existingChapters == null)
                return NotFound($"No se encontró el capítulo con ID {id}.");

            // Actualización controlada de campos específicos
            existingChapters.ChapterTitle = chapters.ChapterTitle;
            // Puedes agregar más propiedades aquí según el modelo

            _unitOfWork.Chapters.Update(existingChapters);
            await _unitOfWork.SaveAsync();

            return Ok(existingChapters);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var chapters = await _unitOfWork.Chapters.GetByIdAsync(id);
            if (chapters == null)
                return NotFound();

        _unitOfWork.Chapters.Remove(chapters);
        await _unitOfWork.SaveAsync();

        return NoContent();
        }
    }
}