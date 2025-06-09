using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;
using Application.DTOs;
using AutoMapper;

namespace ApiProject.Controllers
{
    public class SubQuestionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubQuestionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SubQuestionsDto>>> Get()
        {
            var subQuestions = await _unitOfWork.SubQuestions.GetAllAsync();
            return  _mapper.Map<List<SubQuestionsDto>>(subQuestions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubQuestionsDto>> Get(int id)
        {
            var subQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
            if (subQuestion == null)
            {
                return NotFound($"Sub Question with id {id} was not found.");
            }
            return Ok(_mapper.Map<SubQuestionsDto>(subQuestion));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubQuestions>> Post(SubQuestionsDto subQuestionDto)
        {
            var subQuestion = _mapper.Map<SubQuestions>(subQuestionDto);
            _unitOfWork.SubQuestions.Add(subQuestion);
            await _unitOfWork.SaveAsync();
            if (subQuestion == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = subQuestionDto.Id }, subQuestion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] SubQuestionsDto subQuestionDto)
        {
            // Validación: objeto nulo
            if (subQuestionDto == null)
                return NotFound();

            var subQuestion = _mapper.Map<SubQuestions>(subQuestionDto);
            _unitOfWork.SubQuestions.Update(subQuestion);
            await _unitOfWork.SaveAsync();
            return Ok(subQuestionDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var subQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
            if (subQuestion == null)
                return NotFound();

        _unitOfWork.SubQuestions.Remove(subQuestion);
        await _unitOfWork.SaveAsync();

        return NoContent();
        }
    }
}