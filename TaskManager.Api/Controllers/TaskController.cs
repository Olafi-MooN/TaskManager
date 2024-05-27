using Microsoft.AspNetCore.Mvc;
using PetfolioAll.Communication.Responses;
using TaskManager.Application.UseCases.Tasks.Create;
using TaskManager.Application.UseCases.Tasks.Get;
using TaskManager.Application.UseCases.Tasks.NewFolder;
using TaskManager.Application.UseCases.Tasks.Update;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{

    private readonly CreateTaskUseCase _createTaskUseCase;
    private readonly GetTaskUseCase _getTaskUseCase;
    private readonly UpdateTaskUseCase _updateTaskUseCase;
    private readonly DeleteTaskUseCase _deleteTaskUseCase;

    public TaskController(CreateTaskUseCase createTaskUseCase, GetTaskUseCase getTaskUseCase, UpdateTaskUseCase updateTaskUseCase, DeleteTaskUseCase deleteTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _getTaskUseCase = getTaskUseCase;
        _updateTaskUseCase = updateTaskUseCase;
        _deleteTaskUseCase = deleteTaskUseCase;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestTaskJson request)
    {
        _createTaskUseCase.Execute(request);
        return Created(string.Empty, request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetAllTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Get([FromQuery] Guid? id = null)
    {
        if (id == null)
            return Ok(_getTaskUseCase.Execute());

        return Ok(_getTaskUseCase.Execute(id));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Get([FromBody] Communication.Entity.Task request)
    {
        _updateTaskUseCase.Execute(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Get([FromQuery] Guid id)
    {
        _deleteTaskUseCase.Execute(id);
        return NoContent();
    }

}
