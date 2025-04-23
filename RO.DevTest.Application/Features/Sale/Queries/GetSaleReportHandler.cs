using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Features.Sale.Queries;
using RO.DevTest.Application.DTOs;

using Microsoft.EntityFrameworkCore;

namespace RO.DevTest.Application.Features.Sale.Queries.GetSalesReport;

public class GetSalesReportQueryHandler : IRequestHandler<GetSalesReportQuery, SalesReportResult>
{
    private readonly ISaleRepository _saleRepository;

    public GetSalesReportQueryHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<SalesReportResult> Handle(GetSalesReportQuery request, CancellationToken cancellationToken)
    {
        return await _saleRepository.GetSalesReportAsync(request.StartDate, request.EndDate);
    }
}