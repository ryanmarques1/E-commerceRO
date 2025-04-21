using MediatR;


namespace RO.DevTest.Application.Features.User.Commands.DeleteUserCommand;

public class DeleteUserCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}