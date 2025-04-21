using MediatR;
using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;

public class UpdateProductCommand : IRequest<Unit>{
    public UpdateProductDto Product {get;set;}

    public UpdateProductCommand(UpdateProductDto product){
        Product = product;
    }
}