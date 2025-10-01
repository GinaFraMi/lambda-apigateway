using Microsoft.AspNetCore.Mvc;
using LambdaApiGateway.Application.Services;
using LambdaApiGateway.Domain.Entities;
using LambdaApiGateway.Application.Interfaces;

namespace LambdaApiGateway.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _svc;

    public UsersController(IUserService svc) => _svc = svc;

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(string id, CancellationToken ct)
    {
        var user = await _svc.GetByIdAsync(id, ct);
        return user is null ? NotFound() : Ok(user);
    }

    public record CreateUserRequest(string Email, string Name);

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] CreateUserRequest req, CancellationToken ct)
    {
        var created = await _svc.CreateAsyn(req.Email, req.Name, ct);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpGet("/health")]
    public IActionResult Health() => Ok(new { status = "ok" });
}
