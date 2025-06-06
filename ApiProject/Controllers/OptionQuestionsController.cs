using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;

namespace ApiProject.Controllers
{
    public class OptionQuestionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public OptionQuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OptionQuestions>>> Get()
        {
            var optionQuestions = await _unitOfWork.OptionQuestions.GetAllAsync();
            return Ok(optionQuestions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var optionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
            if (optionQuestion == null)
            {
                return NotFound($"Option Question with id {id} was not found.");
            }
            return Ok(optionQuestion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OptionQuestions>> Post(OptionQuestions optionQuestion)
        {
            _unitOfWork.OptionQuestions.Add(optionQuestion);
            await _unitOfWork.SaveAsync();
            if (optionQuestion == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = optionQuestion.Id }, optionQuestion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] OptionQuestions optionQuestions)
        {
            // Validación: objeto nulo
            if (optionQuestions == null)
            {
                return BadRequest("Option Questions object is null.");
            }

            // Validación: ID no coincide
            if (id != optionQuestions.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var existingOptionQuestions = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
            if (existingOptionQuestions == null)
                return NotFound($"No se encontró la opción de pregunta con ID {id}.");

            // Actualización controlada de campos específicos
            existingOptionQuestions.CommentOptionres = optionQuestions.CommentOptionres;
            // Puedes agregar más propiedades aquí según el modelo

            _unitOfWork.OptionQuestions.Update(existingOptionQuestions);
            await _unitOfWork.SaveAsync();

            return Ok(existingOptionQuestions);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
        var optionQuestions = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
        if (optionQuestions == null)
            return NotFound();

        _unitOfWork.OptionQuestions.Remove(optionQuestions);
        await _unitOfWork.SaveAsync();

        return NoContent();
        }
    }
}