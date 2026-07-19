using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialSummaryReports;

public class AssetFinancialSummaryReportCommandHandlers : 
    IRequestHandler<CreateAssetFinancialSummaryReportCommand, long>,
    IRequestHandler<UpdateAssetFinancialSummaryReportCommand, bool>,
    IRequestHandler<DeleteAssetFinancialSummaryReportCommand, bool>
{
    private readonly IGenericRepository<AssetFinancialSummaryReport> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AssetFinancialSummaryReportCommandHandlers(IGenericRepository<AssetFinancialSummaryReport> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAssetFinancialSummaryReportCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AssetFinancialSummaryReport>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAssetFinancialSummaryReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFinancialSummaryReport not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAssetFinancialSummaryReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFinancialSummaryReport not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}