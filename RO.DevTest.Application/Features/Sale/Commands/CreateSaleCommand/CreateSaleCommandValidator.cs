using FluentValidation;

namespace RO.DevTest.Application.Features.Sale.Commands.CreateSaleCommand;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.IdUser).NotEmpty().WithMessage("Id do usuário é OBRIGATÓRIO.");
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("A venda não pode conter 0(zero) itens.");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            //item.RuleFor(i => i.ProductId).GreaterThan(0);
            item.RuleFor(i => i.QuantitySale).GreaterThan(0);
        });
    }
}
