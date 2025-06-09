using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;
using Application.DTOs;
using AutoMapper;

namespace ApiProject.Controllers
{
    public class OptionQuestionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OptionQuestionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OptionQuestionsDto>>> Get()
        {
            var optionQuestions = await _unitOfWork.OptionQuestions.GetAllAsync();
            return _mapper.Map<List<OptionQuestionsDto>>(optionQuestions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OptionQuestionsDto>> Get(int id)
        {
            var optionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
            if (optionQuestion == null)
            {
                return NotFound($"Option Question with id {id} was not found.");
            }
            return Ok(_mapper.Map<OptionQuestionsDto>(optionQuestion));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OptionQuestions>> Post(OptionQuestionsDto optionQuestionDto)
        {
            var optionQuestion = _mapper.Map<OptionQuestions>(optionQuestionDto);
            _unitOfWork.OptionQuestions.Add(optionQuestion);
            await _unitOfWork.SaveAsync();
            if (optionQuestion == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = optionQuestionDto.Id }, optionQuestion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] OptionQuestionsDto optionQuestionsDto)
        {
            // Validación: objeto nulo
            if (optionQuestionsDto == null)
                return NotFound();

            var optionQuestions = _mapper.Map<OptionQuestions>(optionQuestionsDto);
            _unitOfWork.OptionQuestions.Update(optionQuestions);
            await _unitOfWork.SaveAsync();
            return Ok(optionQuestionsDto);
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