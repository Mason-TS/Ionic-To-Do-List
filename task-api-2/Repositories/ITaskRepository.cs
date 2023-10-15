using TaskModel = task_api_2.Models.Task;

namespace task_api_2.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskModel> GetAllTasks();
    TaskModel? GetTaskById (int taskId);
    TaskModel CreateTask(TaskModel newTask);
    TaskModel? UpdateTask(TaskModel newTask);
    void DeleteTaskById(int taskId);

}