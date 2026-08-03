using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassroomResourceAllocations;

public class ClassroomResourceAllocationCommandHandlers : 
    IRequestHandler<CreateClassroomResourceAllocationCommand, long>,
    IRequestHandler<UpdateClassroomResourceAllocationCommand, bool>,
    IRequestHandler<DeleteClassroomResourceAllocationCommand, bool>
{
    private readonly IGenericRepository<ClassroomResourceAllocation> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClassroomResourceAllocationCommandHandlers(IGenericRepository<ClassroomResourceAllocation> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateClassroomResourceAllocationCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ClassroomResourceAllocation>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateClassroomResourceAllocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassroomResourceAllocation not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteClassroomResourceAllocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassroomResourceAllocation not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}