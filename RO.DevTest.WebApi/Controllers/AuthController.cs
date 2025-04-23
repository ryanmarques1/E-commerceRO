using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

using RO.DevTest.Application.Features.Auth.Commands.LoginCommand;
namespace RO.DevTest.WebApi.Controllers;

[Route("api/auth")]
[OpenApiTags("Auth")]
public class AuthController(IMediator mediator) : Controller {
    private readonly IMediator _mediator = mediator;

    ///[TODO] - CREATE LOGIN HANDLER HERE 
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.AccessToken == null)
            return Unauthorized(new { message = "Nome de usuário inválido ou senha inválida." });

        return Ok(result);
    }
}
