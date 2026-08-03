using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.SystemReports;

public class SystemReportCommandHandlers : 
    IRequestHandler<DraftSystemReportCommand, long>,
    IRequestHandler<ApproveSystemReportCommand, bool>
{
    private readonly IGenericRepository<SystemReport> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public SystemReportCommandHandlers(IGenericRepository<SystemReport> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftSystemReportCommand request, CancellationToken cancellationToken)
    {
        var entity = new SystemReport();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveSystemReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SystemReport not found.");

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}