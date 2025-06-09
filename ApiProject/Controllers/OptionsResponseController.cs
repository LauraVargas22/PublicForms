using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;
using Application.DTOs;
using AutoMapper;

namespace ApiProject.Controllers;

public class OptionsResponseController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OptionsResponseController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OptionsResponseDto>>> Get()
    {
        var optionsResponses = await _unitOfWork.OptionsResponse.GetAllAsync();
        return _mapper.Map<List<OptionsResponseDto>>(optionsResponses);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionsResponseDto>> Get(int id)
    {
        var optionsResponse = await _unitOfWork.OptionsResponse.GetByIdAsync(id);
        if (optionsResponse == null)
        {
            return NotFound($"Options Response with id {id} was not found.");
        }
        return Ok(_mapper.Map<OptionsResponseDto>(optionsResponse));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionsResponse>> Post(OptionsResponseDto optionsResponseDto)
    {
        var optionsResponse = _mapper.Map<OptionsResponse>(optionsResponseDto);
        _unitOfWork.OptionsResponse.Add(optionsResponse);
        await _unitOfWork.SaveAsync();
        if (optionsResponse == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = optionsResponseDto.Id }, optionsResponse);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] OptionsResponseDto optionsResponseDto)
    {
        // Validación: objeto nulo
        if (optionsResponseDto == null)
            return NotFound();

        var optionsResponse = _mapper.Map<OptionsResponse>(optionsResponseDto);
        _unitOfWork.OptionsResponse.Update(optionsResponse);
        await _unitOfWork.SaveAsync();
        return Ok(optionsResponseDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
    var optionsResponse = await _unitOfWork.OptionsResponse.GetByIdAsync(id);
    if (optionsResponse == null)
        return NotFound();

    _unitOfWork.OptionsResponse.Remove(optionsResponse);
    await _unitOfWork.SaveAsync();

    return NoContent();
    }
}
