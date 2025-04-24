using FluentValidation;

namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>{
    public CreateProductCommandValidator() {
        RuleFor(cpau => cpau.nameProd)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Nome do Produto deve ser preenchido.");

        RuleFor(cpau => cpau.descriptionProd)
                .NotEmpty()
                .WithMessage("A Descrição do produto deve ser preenchido.");

        RuleFor(cpau => cpau.priceProd)
            .NotEmpty()
            .WithMessage("O campo preço deve ser preenchido.");

        RuleFor(cpau => cpau.quantityStock)
            .NotEmpty()
            .WithMessage("Coloque um numero inteiro.");
    }
}
