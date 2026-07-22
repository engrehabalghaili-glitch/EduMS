using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Commands.EducationalConsumableTrackings;

public class EducationalConsumableTrackingCommandHandlers : 
    IRequestHandler<CreateEducationalConsumableTrackingCommand, long>,
    IRequestHandler<UpdateEducationalConsumableTrackingCommand, bool>,
    IRequestHandler<DeleteEducationalConsumableTrackingCommand, bool>
{
    private readonly IGenericRepository<EducationalConsumableTracking> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EducationalConsumableTrackingCommandHandlers(IGenericRepository<EducationalConsumableTracking> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateEducationalConsumableTrackingCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<EducationalConsumableTracking>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateEducationalConsumableTrackingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EducationalConsumableTracking not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteEducationalConsumableTrackingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EducationalConsumableTracking not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}