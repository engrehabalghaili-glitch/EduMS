using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.KpiMetricRecords;

public class KpiMetricRecordCommandHandlers : 
    IRequestHandler<DraftKpiMetricRecordCommand, long>,
    IRequestHandler<ApproveKpiMetricRecordCommand, bool>
{
    private readonly IGenericRepository<KpiMetricRecord> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KpiMetricRecordCommandHandlers(IGenericRepository<KpiMetricRecord> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftKpiMetricRecordCommand request, CancellationToken cancellationToken)
    {
        // 1. Execute dynamic MediatR query to get JSON calculation
        // 2. Save it as Draft
        var entity = new KpiMetricRecord();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveKpiMetricRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"KpiMetricRecord not found.");

        // Mark as approved (Workflow status)
        // entity.ApprovalStatus = 2; // e.g. Approved
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}