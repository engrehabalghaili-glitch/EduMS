using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateLegalCaseLogs;

public class DirectorateLegalCaseLogCommandHandlers : 
    IRequestHandler<CreateDirectorateLegalCaseLogCommand, long>,
    IRequestHandler<UpdateDirectorateLegalCaseLogCommand, bool>,
    IRequestHandler<DeleteDirectorateLegalCaseLogCommand, bool>
{
    private readonly IGenericRepository<DirectorateLegalCaseLog> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DirectorateLegalCaseLogCommandHandlers(IGenericRepository<DirectorateLegalCaseLog> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateDirectorateLegalCaseLogCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<DirectorateLegalCaseLog>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateDirectorateLegalCaseLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DirectorateLegalCaseLog not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteDirectorateLegalCaseLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DirectorateLegalCaseLog not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}