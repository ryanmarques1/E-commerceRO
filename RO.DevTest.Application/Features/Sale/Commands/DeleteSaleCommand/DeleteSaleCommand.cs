using MediatR;


namespace RO.DevTest.Application.Features.Sale.Commands.DeleteSaleCommand;

public class DeleteSaleCommand : IRequest<Unit>{
    public Guid Idsale {get;set;}

    public DeleteSaleCommand(Guid id){
        Idsale = id;
    }
}