using HireLatam.Application.Features.Todos;
using HireLatam.Domain.Todos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HireLatam.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ISender _sender;

    public TodosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _sender.Send(new GetTodosQuery());

        return result.IsSuccessful
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _sender.Send(new GetTodoByIdQuery(id));

        return result.IsSuccessful
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] TodoRequest request)
    {
        var result = await _sender.Send(new CreateTodoCommand(request));

        return result.IsSuccessful
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        [FromQuery] int id,
        [FromBody] TodoRequest request)
    {
        var result = await _sender.Send(new UpdateTodoCommand(id, request));

        return result.IsSuccessful
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        [FromQuery] int id)
    {
        var result = await _sender.Send(new DeleteTodoCommand(id));

        return result.IsSuccessful
            ? Ok(result)
            : BadRequest(result);
    }
}
