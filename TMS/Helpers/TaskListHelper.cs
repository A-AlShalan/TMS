using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Dtos;
using TMS.Repositories;

namespace TMS.Helpers
{
	public class TaskListHelper: ITaskListRepository
    {
        private readonly AppDBContext _appDbContext;

        public TaskListHelper(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TasksList> AddTasksList(TaskListDto List)
        {
            TasksList tasksList = new TasksList()
            {
                Name = List.Name
            };
             var result =  _appDbContext.TasksLists.Add(tasksList);
             _appDbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<IEnumerable<TasksList>> GetTasksLists()
        {
            return await _appDbContext.TasksLists.Include(t => t.Tasks).ToListAsync();
        }

        public async Task<TasksList> GetTasksList(int taskListId)
        {
            return await _appDbContext.TasksLists.Include(t => t.Tasks)
                .FirstOrDefaultAsync(taskList => taskList.Id == taskListId);
        }

        // Always use soft delete not hard delete.
        public async Task<ActionResult<TasksList>> DeleteTasksList(int taskListId)
        {
            var result = await _appDbContext.TasksLists
                .FirstOrDefaultAsync(taskList => taskList.Id == taskListId);
            if (result is null)
            {
                throw new NotFoundBusinessException($"Task List with id {taskListId} does not exist");
            }
            _appDbContext.TasksLists.Remove(result);
            await _appDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<TasksList> UpdateTasksList(UpdateTaskListDto taskListparam)
        {
            var result = await _appDbContext.TasksLists
                .FirstOrDefaultAsync(taskList => taskList.Id == taskListparam.Id);

            if (result != null)
            {
                result.Name = taskListparam.Name;
                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

