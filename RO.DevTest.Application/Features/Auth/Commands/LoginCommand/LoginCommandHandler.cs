using MediatR;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand;
namespace RO.DevTest.Domain.Entities;

using RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<User> _userManager;

    public LoginCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return new LoginResponse
            {
                AccessToken = null,
                RefreshToken = null,
                Roles = null,
                ExpirationDate = DateTime.UtcNow.AddMinutes(30)
            };
        }

        var roles = await _userManager.GetRolesAsync(user);

        return new LoginResponse
        {
            AccessToken = $"token-{Guid.NewGuid()}", // Apenas ilustrativo
            RefreshToken = $"refresh-{Guid.NewGuid()}",
            Roles = roles.ToList(),
            ExpirationDate = DateTime.UtcNow.AddMinutes(30)
        };
    }
}
