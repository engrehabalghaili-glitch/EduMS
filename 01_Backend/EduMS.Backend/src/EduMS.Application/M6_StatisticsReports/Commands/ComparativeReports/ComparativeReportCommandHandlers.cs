using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.ComparativeReports;

public class ComparativeReportCommandHandlers : 
    IRequestHandler<DraftComparativeReportCommand, long>,
    IRequestHandler<ApproveComparativeReportCommand, bool>
{
    private readonly IGenericRepository<ComparativeReport> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ComparativeReportCommandHandlers(IGenericRepository<ComparativeReport> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftComparativeReportCommand request, CancellationToken cancellationToken)
    {
        var entity = new ComparativeReport();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveComparativeReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ComparativeReport not found.");

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}