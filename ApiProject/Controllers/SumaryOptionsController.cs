using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;

namespace ApiProject.Controllers
{
    public class SumaryOptionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public SumaryOptionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SumaryOptions>>> Get()
        {
            var sumaryOptions = await _unitOfWork.SumaryOptions.GetAllAsync();
            return Ok(sumaryOptions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var sumaryOptions = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
            if (sumaryOptions == null)
            {
                return NotFound($"Sumary Options with id {id} was not found.");
            }
            return Ok(sumaryOptions);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SumaryOptions>> Post(SumaryOptions sumaryOptions)
        {
            _unitOfWork.SumaryOptions.Add(sumaryOptions);
            await _unitOfWork.SaveAsync();
            if (sumaryOptions == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = sumaryOptions.Id }, sumaryOptions);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] SumaryOptions sumaryOptions)
        {
            // Validación: objeto nulo
            if (sumaryOptions == null)
                return BadRequest("El cuerpo de la solicitud está vacío.");

            // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
            if (id != sumaryOptions.Id)
                return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

            // Verificación: el recurso debe existir antes de actualizar
            var existingSumaryOptions = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
            if (existingSumaryOptions == null)
                return NotFound($"No se encontró la opción de resumen con ID {id}.");

            // Actualización controlada de campos específicos
            existingSumaryOptions.Valuerta = sumaryOptions.Valuerta;
            // Puedes agregar más propiedades aquí según el modelo

            _unitOfWork.SumaryOptions.Update(existingSumaryOptions);
            await _unitOfWork.SaveAsync();

            return Ok(existingSumaryOptions);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var sumaryOptions = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
            if (sumaryOptions == null)
                return NotFound(); 

            _unitOfWork.SumaryOptions.Remove(sumaryOptions);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}