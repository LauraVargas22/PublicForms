using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Controllers;
using Application.DTOs;
using AutoMapper;

namespace ApiProject.Controllers
{
    public class ChaptersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChaptersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ChaptersDto>>> Get()
        {
            var chapters = await _unitOfWork.Chapters.GetAllAsync();
            return _mapper.Map<List<ChaptersDto>>(chapters);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ChaptersDto>> Get(int id)
        {
            var chapters = await _unitOfWork.Chapters.GetByIdAsync(id);
            if (chapters == null)
            {
                return NotFound($"Chapters with id {id} was not found.");
            }
            return Ok(_mapper.Map<ChaptersDto>(chapters));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Chapters>> Post(ChaptersDto chaptersDto)
        {
            var chapters = _mapper.Map<Chapters>(chaptersDto);
            _unitOfWork.Chapters.Add(chapters);
            await _unitOfWork.SaveAsync();
            if (chapters == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = chaptersDto.Id }, chapters);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] ChaptersDto chaptersDto)
        {
            // Validación: objeto nulo
            if (chaptersDto == null)
                return NotFound();

            var chapters = _mapper.Map<Chapters>(chaptersDto);
            _unitOfWork.Chapters.Update(chapters);
            await _unitOfWork.SaveAsync();
            return Ok(chaptersDto);
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