
using TMS.Dtos;

namespace TMS.Repositories
{
	public interface ITaskRepository
	{
        IEnumerable<Tasks> GetTasks(FilterTask? filterTask);
        Task<Tasks> GetTask(int TasksTaskId);
        Task<Tasks> AddTask(TaskDto TasksTask);
        Task<Tasks> UpdateTaskList(int id, UpdateTaskDto task);
        Task<Tasks> DeleteTask(int TaskId);
        List<Tasks> GetTaskByUser(int id);
    }
}

