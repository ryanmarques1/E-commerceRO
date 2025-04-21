using MediatR;

using RO.DevTest.Application.Contracts.Persistance.Repositories;
namespace RO.DevTest.Application.Features.User.Commands.DeleteUserCommand;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw new Exception("Usuário não encontrado");

        await _userRepository.DeleteAsync(user);
        Console.WriteLine($"Usuário com ID{user.Id} foi removido com sucesso.");
        return Unit.Value;
    }
}