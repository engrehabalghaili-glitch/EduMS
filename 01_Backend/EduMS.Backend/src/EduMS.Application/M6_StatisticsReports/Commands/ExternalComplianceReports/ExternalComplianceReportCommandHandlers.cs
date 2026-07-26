using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.ExternalComplianceReports;

public class ExternalComplianceReportCommandHandlers : 
    IRequestHandler<DraftExternalComplianceReportCommand, long>,
    IRequestHandler<ApproveExternalComplianceReportCommand, bool>
{
    private readonly IGenericRepository<ExternalComplianceReport> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ExternalComplianceReportCommandHandlers(IGenericRepository<ExternalComplianceReport> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftExternalComplianceReportCommand request, CancellationToken cancellationToken)
    {
        var entity = new ExternalComplianceReport();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveExternalComplianceReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ExternalComplianceReport not found.");

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}