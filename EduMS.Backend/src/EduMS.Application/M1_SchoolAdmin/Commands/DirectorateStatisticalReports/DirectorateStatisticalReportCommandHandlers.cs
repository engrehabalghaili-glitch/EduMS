using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateStatisticalReports;

public class DirectorateStatisticalReportCommandHandlers : 
    IRequestHandler<CreateDirectorateStatisticalReportCommand, long>,
    IRequestHandler<UpdateDirectorateStatisticalReportCommand, bool>,
    IRequestHandler<DeleteDirectorateStatisticalReportCommand, bool>
{
    private readonly IGenericRepository<DirectorateStatisticalReport> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DirectorateStatisticalReportCommandHandlers(IGenericRepository<DirectorateStatisticalReport> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateDirectorateStatisticalReportCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<DirectorateStatisticalReport>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateDirectorateStatisticalReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DirectorateStatisticalReport not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteDirectorateStatisticalReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DirectorateStatisticalReport not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}