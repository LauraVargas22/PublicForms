using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;
using Application.DTOs;
using AutoMapper;

namespace ApiProject.Controllers;

public class QuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public QuestionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<QuestionsDto>>> Get()
    {
        var questions = await _unitOfWork.Questions.GetAllAsync();
        return _mapper.Map<List<QuestionsDto>>(questions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<QuestionsDto>> Get(int id)
    {
        var questions = await _unitOfWork.Questions.GetByIdAsync(id);
        if (questions == null)
        {
            return NotFound($"Questions with id {id} was not found.");
        }
        return Ok(_mapper.Map<QuestionsDto>(questions));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Questions>> Post(QuestionsDto questionsDto)
    {
        var questions = _mapper.Map<Questions>(questionsDto);
        _unitOfWork.Questions.Add(questions);
        await _unitOfWork.SaveAsync();
        if (questions == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = questions.Id }, questions);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] QuestionsDto questionsDto)
    {
        // Validación: objeto nulo
        if (questionsDto == null)
            return NotFound();

        var questions = _mapper.Map<Questions>(questionsDto);
        _unitOfWork.Questions.Update(questions);
        await _unitOfWork.SaveAsync();
        return Ok(questionsDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var questions = await _unitOfWork.Questions.GetByIdAsync(id);
        if (questions == null)
            return NotFound();

        _unitOfWork.Questions.Remove(questions);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
