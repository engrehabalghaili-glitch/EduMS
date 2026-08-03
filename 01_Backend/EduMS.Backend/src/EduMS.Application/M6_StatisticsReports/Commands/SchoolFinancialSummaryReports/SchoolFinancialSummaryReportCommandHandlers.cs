using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.SchoolFinancialSummaryReports;

public class SchoolFinancialSummaryReportCommandHandlers : 
    IRequestHandler<DraftSchoolFinancialSummaryReportCommand, long>,
    IRequestHandler<ApproveSchoolFinancialSummaryReportCommand, bool>
{
    private readonly IGenericRepository<SchoolFinancialSummaryReport> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public SchoolFinancialSummaryReportCommandHandlers(IGenericRepository<SchoolFinancialSummaryReport> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftSchoolFinancialSummaryReportCommand request, CancellationToken cancellationToken)
    {
        var entity = new SchoolFinancialSummaryReport();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveSchoolFinancialSummaryReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolFinancialSummaryReport not found.");

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}