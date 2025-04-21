using MediatR;
using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Features.User.Commands.UpdateUserCommand;

public class UpdateUserCommand : IRequest <Unit>{
    public UpdateUserDto User {get;set;}

    public UpdateUserCommand(UpdateUserDto user){
        User = user;
    }
}