using Microsoft.AspNetCore.Mvc;
using TMS.Dtos;

namespace TMS.Repositories
{
	public interface ITaskListRepository
	{
            Task<IEnumerable<TasksList>> GetTasksLists();
            Task<TasksList> GetTasksList(int TasksListId);
            Task<TasksList> AddTasksList(TaskListDto TasksList);
            Task<TasksList> UpdateTasksList(UpdateTaskListDto TasksList);
            Task<ActionResult<TasksList>> DeleteTasksList(int TasksListId);
    }
}

