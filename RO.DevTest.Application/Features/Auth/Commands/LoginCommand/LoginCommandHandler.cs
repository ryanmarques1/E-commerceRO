using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using System.Security.Claims;
using System.Text;
using RO.DevTest.Domain.Entities;
namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse> {
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken) {
        ///[TODO] - CREATE LOGIN HANDLER HERE    
        
        throw new NotImplementedException();
    }
}
