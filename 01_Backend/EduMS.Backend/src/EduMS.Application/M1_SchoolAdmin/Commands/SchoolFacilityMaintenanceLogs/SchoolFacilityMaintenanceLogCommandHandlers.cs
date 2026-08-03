using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolFacilityMaintenanceLogs;

public class SchoolFacilityMaintenanceLogCommandHandlers : 
    IRequestHandler<CreateSchoolFacilityMaintenanceLogCommand, long>,
    IRequestHandler<UpdateSchoolFacilityMaintenanceLogCommand, bool>,
    IRequestHandler<DeleteSchoolFacilityMaintenanceLogCommand, bool>
{
    private readonly IGenericRepository<SchoolFacilityMaintenanceLog> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SchoolFacilityMaintenanceLogCommandHandlers(IGenericRepository<SchoolFacilityMaintenanceLog> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateSchoolFacilityMaintenanceLogCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<SchoolFacilityMaintenanceLog>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateSchoolFacilityMaintenanceLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolFacilityMaintenanceLog not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteSchoolFacilityMaintenanceLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolFacilityMaintenanceLog not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}