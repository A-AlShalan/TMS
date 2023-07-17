using TMS.Dtos;
using Microsoft.AspNetCore.Mvc;
using TMS.Repositories;
using TMS.Helpers;

namespace TMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {

            _taskRepository = taskRepository;
        }

        [HttpGet]
        public IEnumerable<Tasks> Get([FromQuery] FilterTask? filter)
        {
            return _taskRepository.GetTasks(filter);
        }

        [HttpPost]
        public async Task<ActionResult<Tasks>> Post(TaskDto input)
        {
            var createsTask = await _taskRepository.AddTask(input);
            return createsTask;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Tasks>> DeleteTask(int id)
        {
            return await _taskRepository.DeleteTask(id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Tasks>> UpdateTaskList(int id, UpdateTaskDto tasksList)
        {
            var result = await _taskRepository.UpdateTaskList(id, tasksList);
            if (result is null)
            {
                throw new NotFoundBusinessException($"Task List with Id = {id} not found");
            }
            return result;
        }

        [HttpGet("Users/{id:int}")]
        public List<Tasks> GetTasksByUser(int id)
        {
           return _taskRepository.GetTaskByUser(id);
        }
    }
}

