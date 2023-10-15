using Microsoft.Extensions.ObjectPool;
using task_api_2.Migrations;
using TaskModel = task_api_2.Models.Task;

namespace task_api_2.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TaskModel> GetAllTasks() 
    {
        return _context.Tasks.ToList();
    }

    public TaskModel? GetTaskById(int taskId)
    {
        return _context.Tasks.SingleOrDefault(t => t.TaskId == taskId);
    }

    public TaskModel CreateTask(TaskModel newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    public TaskModel? UpdateTask(TaskModel newTask)
    {
        var originalTask = _context.Tasks.Find(newTask.TaskId);

        if (originalTask != null)
        {
            originalTask.Title = newTask.Title;
            originalTask.Completed = newTask.Completed;
            _context.SaveChanges();
        }
        return originalTask;
    }

    public void DeleteTaskById(int taskId)
    {
        var task = _context.Tasks.Find(taskId);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}