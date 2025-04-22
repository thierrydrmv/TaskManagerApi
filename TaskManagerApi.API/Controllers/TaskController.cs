using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Application.DTOs;
using TaskManagerApi.Application.Services;
using TaskManagerApi.Domain.Entities;

namespace TaskManagerApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(TaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _taskService.ListAsync();
            return Ok(_mapper.Map<List<AppTaskDto>>(tasks));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            return Ok(_mapper.Map<AppTaskDto>(task));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAppTaskDto taskDto)
        {
            var entity = _mapper.Map<AppTask>(taskDto);
            await _taskService.CreateAsync(entity);
            return CreatedAtAction(nameof(Get), new {id = entity.Id}, _mapper.Map<AppTaskDto>(taskDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAppTaskDto taskDto)
        {
            if (id != taskDto.Id)
                return BadRequest();

            var entity = _mapper.Map<AppTask>(taskDto);
            await _taskService.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _taskService.DeleteAsync(id);
            return NoContent();
        }
    }
}
