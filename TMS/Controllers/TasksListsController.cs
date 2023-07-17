using Microsoft.AspNetCore.Mvc;
using TMS.Dtos;
using TMS.Helpers;
using TMS.Repositories;
namespace TMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksListsController : ControllerBase
    {
        private readonly ITaskListRepository taskListHelper;

        public TasksListsController(ITaskListRepository taskListRepository)
        {
            taskListHelper = taskListRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TasksList>> GetTasksListsAsync()
        {
                return await taskListHelper.GetTasksLists();
        }

        [HttpPost]
        public async Task<ActionResult<TasksList>> createTaskListAsync(TaskListDto input)
        {
            return await taskListHelper.AddTasksList(input);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TasksList>> DeleteTaskList(int id)
        {
            return await taskListHelper.DeleteTasksList(id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TasksList>> UpdateTaskList(int id, UpdateTaskListDto tasksList)
        {
                if (id != tasksList.Id)
                {
                    throw new ConflictBusinessException("Task List ID mismatch");
                }

                var taskListToUpdate = await taskListHelper.GetTasksList(id);

                if (taskListToUpdate is null)
                {
                    throw new NotFoundBusinessException($"Task List with Id = {id} not found");
                }

                return await taskListHelper.UpdateTasksList(tasksList);
           
        }
    }
}

