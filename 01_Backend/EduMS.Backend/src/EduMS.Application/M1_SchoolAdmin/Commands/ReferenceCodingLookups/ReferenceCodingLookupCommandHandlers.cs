using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ReferenceCodingLookups;

public class ReferenceCodingLookupCommandHandlers : 
    IRequestHandler<CreateReferenceCodingLookupCommand, long>,
    IRequestHandler<UpdateReferenceCodingLookupCommand, bool>,
    IRequestHandler<DeleteReferenceCodingLookupCommand, bool>
{
    private readonly IGenericRepository<ReferenceCodingLookup> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReferenceCodingLookupCommandHandlers(IGenericRepository<ReferenceCodingLookup> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateReferenceCodingLookupCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ReferenceCodingLookup>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateReferenceCodingLookupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ReferenceCodingLookup not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteReferenceCodingLookupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ReferenceCodingLookup not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}