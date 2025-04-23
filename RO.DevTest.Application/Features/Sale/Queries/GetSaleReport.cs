using MediatR;
using RO.DevTest.Application.DTOs;
namespace RO.DevTest.Application.Features.Sale.Queries;

public class GetSalesReportQuery : IRequest<SalesReportResult>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}