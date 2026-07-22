using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicBranchConfigLogs;

public class AcademicBranchConfigLogCommandHandlers : 
    IRequestHandler<CreateAcademicBranchConfigLogCommand, long>,
    IRequestHandler<UpdateAcademicBranchConfigLogCommand, bool>,
    IRequestHandler<DeleteAcademicBranchConfigLogCommand, bool>
{
    private readonly IGenericRepository<AcademicBranchConfigLog> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AcademicBranchConfigLogCommandHandlers(IGenericRepository<AcademicBranchConfigLog> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAcademicBranchConfigLogCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AcademicBranchConfigLog>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAcademicBranchConfigLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AcademicBranchConfigLog not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAcademicBranchConfigLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AcademicBranchConfigLog not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}