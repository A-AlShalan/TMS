using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TMS.Dtos;
using TMS.Repositories;

namespace TMS.Helpers
{
    public class TaskHelper : ITaskRepository
    {
        private readonly AppDBContext _appDbContext;
        private readonly IMapper _mapper;

        public TaskHelper(AppDBContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<Tasks> AddTask(TaskDto input) // Task Dto
        {
            Tasks taskToBeCreated = new Tasks()
            {
                Title = input.Title,
                Description = input.Description,
                Priority = input.Priority,
                TaskStatus = input.TaskStatus,
                TasksListId = input.tasksListId,
                DueDate = input.DueDate
            };
            var result = _appDbContext.Tasks.Add(taskToBeCreated);
            _appDbContext.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<Tasks> GetTasks(FilterTask? filterTask)
        {
            var result = new List<Tasks>();
            result = _appDbContext.Tasks.ToList(); // Remove this line. 
            result = filterTask?.Status > 0 ? result.Where(t => (int)t.TaskStatus == filterTask.Status).ToList() : result; //filter by status
            result = filterTask?.Priority > 0 ? result.Where(t => (int)t.Priority == filterTask.Priority).ToList() : result; // filter by priority
            result = filterTask?.OrderBy?.ToLower() == "PRIORITY".ToLower() ? result.OrderBy(t => t.Priority).ToList() : result; // order by priority
            if (filterTask?.OrderBy?.ToLower() == "PRIORITY".ToLower())
            {
                result = result.OrderBy(t => t.Priority).ToList();
            }
            if (filterTask?.OrderBy?.ToLower() == "DUEDATE".ToLower())
            {
                result = result.OrderBy(t => t.DueDate).ToList();
            }
            if (filterTask?.DueDate is not null)
            {
                result = result.Where(task => task.DueDate.Year == filterTask.DueDate.Value.Year && task.DueDate.Month == filterTask.DueDate.Value.Month && task.DueDate.Day == filterTask.DueDate.Value.Day)
                        .ToList();
            }
            return result;
        }

        public async Task<Tasks> GetTask(int id)
        {
            var result = await _appDbContext.Tasks.FirstOrDefaultAsync(taskList => taskList.Id == id);
            if (result is null)
            {
                throw new NotFoundBusinessException($"Task with id {id} does not exist");
            }
            return result;
        }

        public List<Tasks> GetTaskByUser(int id)
        {
            var user = _appDbContext.Users.Where(user => user.Id == id).ToList();
            if (user.Count == 0)
            {
                throw new NotFoundBusinessException("User Id is not Exists");
            }
            var task = _appDbContext.Tasks.Where(task => task.UserId == id).ToList();
            if (task is null)
            {
                throw new NotFoundBusinessException("No tasks were assigned to this user.");
            }
            return task;
        }

        public async Task<Tasks> DeleteTask(int id)
        {
            var result = await _appDbContext.Tasks
               .FirstOrDefaultAsync(task => task.Id == id);
            if (result != null)
            {
                _appDbContext.Tasks.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;

        }

        public async Task<Tasks> UpdateTaskList(int id, UpdateTaskDto tasksList)
        {
            var task = await GetTask(id);
            if (task is null)
            {
                throw new NotFoundBusinessException($"Task with Id:{id} does not exist");
            }
            task = _mapper.Map(tasksList , task);
            _appDbContext.Update(task);
            await _appDbContext.SaveChangesAsync();
            return task;
        }
    }
}

