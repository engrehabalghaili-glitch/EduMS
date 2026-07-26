using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.SchoolStatisticsDrafts;

public class SchoolStatisticsDraftCommandHandlers : 
    IRequestHandler<DraftSchoolStatisticsDraftCommand, long>,
    IRequestHandler<ApproveSchoolStatisticsDraftCommand, bool>
{
    private readonly IGenericRepository<SchoolStatisticsDraft> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public SchoolStatisticsDraftCommandHandlers(IGenericRepository<SchoolStatisticsDraft> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DraftSchoolStatisticsDraftCommand request, CancellationToken cancellationToken)
    {
        var entity = new SchoolStatisticsDraft();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(ApproveSchoolStatisticsDraftCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolStatisticsDraft not found.");

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}