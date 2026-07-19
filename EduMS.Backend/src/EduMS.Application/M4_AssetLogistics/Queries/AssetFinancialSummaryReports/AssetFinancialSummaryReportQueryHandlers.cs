using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialSummaryReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialSummaryReports;

public class AssetFinancialSummaryReportQueryHandlers : 
    IRequestHandler<GetAssetFinancialSummaryReportByIdQuery, AssetFinancialSummaryReportDto>,
    IRequestHandler<GetAllAssetFinancialSummaryReportsQuery, IEnumerable<AssetFinancialSummaryReportDto>>
{
    private readonly IGenericRepository<AssetFinancialSummaryReport> _repository;
    private readonly IMapper _mapper;

    public AssetFinancialSummaryReportQueryHandlers(IGenericRepository<AssetFinancialSummaryReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetFinancialSummaryReportDto> Handle(GetAssetFinancialSummaryReportByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFinancialSummaryReport not found.");
        return _mapper.Map<AssetFinancialSummaryReportDto>(entity);
    }

    public async Task<IEnumerable<AssetFinancialSummaryReportDto>> Handle(GetAllAssetFinancialSummaryReportsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetFinancialSummaryReportDto>>(entities);
    }
}