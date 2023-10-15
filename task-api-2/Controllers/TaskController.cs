using Microsoft.AspNetCore.Mvc;
using TaskModel = task_api_2.Models.Task;
using task_api_2.Repositories;

namespace task_api_2.Controllers;



[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{

    private readonly ILogger<TaskController> _logger;
    private readonly ITaskRepository _taskrepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _taskrepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskModel>> GetTasks() 
    {
        var tasks = _taskrepository.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet]
    [Route("{taskId:int}")]
    public ActionResult<TaskModel> GetTaskById(int taskId) 
    {
        var task = _taskrepository.GetTaskById(taskId);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskModel> CreateTask(TaskModel task) 
    {
        if(!ModelState.IsValid || task == null)
        {
            return BadRequest();
        }
        var newTask = _taskrepository.CreateTask(task);
        return Created(nameof(GetTaskById), newTask);
    }

    [HttpPut]
    [Route("{taskId:int}")]
    public ActionResult<TaskModel> UpdateTask(TaskModel task) 
    {
        if(!ModelState.IsValid || task == null)
        {
            return BadRequest();
        }
        return Ok(_taskrepository.UpdateTask(task));
    }

    [HttpDelete]
    [Route("{taskId:int}")]
    public ActionResult DeleteTask(int taskId)
    {
        _taskrepository.DeleteTaskById(taskId);
        return NoContent();
    }

    

}