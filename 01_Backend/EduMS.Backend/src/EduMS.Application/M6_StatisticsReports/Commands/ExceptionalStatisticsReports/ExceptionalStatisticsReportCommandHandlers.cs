using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.ExceptionalStatisticsReports;

public class ExceptionalStatisticsReportCommandHandlers : 
    IRequestHandler<DraftExceptionalStatisticsReportCommand, long>,
    IRequestHandler<ApproveExceptionalStatisticsReportCommand, bool>
{
    private readonly IGenericRepository<ExceptionalStatisticsReport> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ExceptionalStatisticsReportCommandHandlers(IGenericRepository<ExceptionalStatisticsReport> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftExceptionalStatisticsReportCommand request, CancellationToken cancellationToken)
    {
        var entity = new ExceptionalStatisticsReport();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveExceptionalStatisticsReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ExceptionalStatisticsReport not found.");

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}