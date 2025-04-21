using MediatR;
using RO.DevTest.Domain.Exception;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
namespace RO.DevTest.Application.Features.User.Commands.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.User.Id);
        if (user == null)
            throw new Exception("Usuário não encontrado");

        user.Name = request.User.UserName;
        user.Email = request.User.Email;

        await _userRepository.UpdateAsync(user);

        Console.WriteLine($"Usuário com ID {user.Id} foi atualizado com sucesso.");
        return Unit.Value;
    }
}