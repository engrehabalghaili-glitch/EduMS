using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissionRecords;

public class BehaviorPermissionRecordCommandHandlers : 
    IRequestHandler<CreateBehaviorPermissionRecordCommand, long>,
    IRequestHandler<UpdateBehaviorPermissionRecordCommand, bool>,
    IRequestHandler<DeleteBehaviorPermissionRecordCommand, bool>
{
    private readonly IGenericRepository<BehaviorPermissionRecord> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BehaviorPermissionRecordCommandHandlers(IGenericRepository<BehaviorPermissionRecord> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateBehaviorPermissionRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<BehaviorPermissionRecord>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateBehaviorPermissionRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"BehaviorPermissionRecord not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteBehaviorPermissionRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"BehaviorPermissionRecord not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}