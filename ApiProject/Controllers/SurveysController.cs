using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;
using Application.DTOs;
using AutoMapper;

namespace ApiProject.Controllers;

public class SurveysController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public SurveysController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SurveysDto>>> Get()
    {
        var surveys = await _unitOfWork.Surveys.GetAllAsync();
        return _mapper.Map<List<SurveysDto>>(surveys);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SurveysDto>> Get(int id)
    {
        var surveys = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (surveys == null)
        {
            return NotFound($"Surveys with id {id} was not found.");
        }
        return Ok(_mapper.Map<SurveysDto>(surveys));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Surveys>> Post(SurveysDto surveysDto)
    {
        var surveys = _mapper.Map<Surveys>(surveysDto);
        _unitOfWork.Surveys.Add(surveys);
        await _unitOfWork.SaveAsync();
        if (surveys == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = surveysDto.Id }, surveys);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SurveysDto surveysDto)
    {
        // Validación: objeto nulo
        if (surveysDto == null)
            return NotFound();

        var surveys = _mapper.Map<Surveys>(surveysDto);
        _unitOfWork.Surveys.Update(surveys);
        await _unitOfWork.SaveAsync();
        return Ok(surveysDto);
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
