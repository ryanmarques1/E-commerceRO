using System.Data;
using FluentValidation;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>{
    public CreateUserCommandValidator() {
        RuleFor(cpau => cpau.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Não pode ser vazio e não pode conter espaços.");
        RuleFor(cpau => cpau.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("O campo e-mail precisa ser preenchido");

        RuleFor(cpau => cpau.Email)
            .EmailAddress()
            .WithMessage("O campo e-mail precisa ser um e-mail válido");

        RuleFor(cpau => cpau.Password)
            .MinimumLength(6)
            .WithMessage("O campo senha precisa ter, pelo menos, 6 caracteres seguindo as seguintes regras. Pelo menos um caractece a-z , A-Z, 0-9, e o conjunto dos caracteres especiais.");

        RuleFor(cpau => cpau.PasswordConfirmation)
            .Matches(cpau => cpau.Password)
            .WithMessage("O campo de confirmação de senha deve ser igual ao campo senha.");
    }
}
