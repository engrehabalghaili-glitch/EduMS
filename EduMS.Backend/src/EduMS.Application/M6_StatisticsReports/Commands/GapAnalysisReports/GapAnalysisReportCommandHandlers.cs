using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.GapAnalysisReports;

public class GapAnalysisReportCommandHandlers : 
    IRequestHandler<DraftGapAnalysisReportCommand, long>,
    IRequestHandler<ApproveGapAnalysisReportCommand, bool>
{
    private readonly IGenericRepository<GapAnalysisReport> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GapAnalysisReportCommandHandlers(IGenericRepository<GapAnalysisReport> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftGapAnalysisReportCommand request, CancellationToken cancellationToken)
    {
        // 1. Execute dynamic MediatR query to get JSON calculation
        // 2. Save it as Draft
        var entity = new GapAnalysisReport();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveGapAnalysisReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"GapAnalysisReport not found.");

        // Mark as approved (Workflow status)
        // entity.ApprovalStatus = 2; // e.g. Approved
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}