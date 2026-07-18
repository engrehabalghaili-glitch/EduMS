using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeExternalTransfers;

public class EmployeeExternalTransferCommandHandlers : 
    IRequestHandler<CreateEmployeeExternalTransferCommand, long>,
    IRequestHandler<UpdateEmployeeExternalTransferCommand, bool>,
    IRequestHandler<DeleteEmployeeExternalTransferCommand, bool>
{
    private readonly IGenericRepository<EmployeeExternalTransfer> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeExternalTransferCommandHandlers(IGenericRepository<EmployeeExternalTransfer> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateEmployeeExternalTransferCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<EmployeeExternalTransfer>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateEmployeeExternalTransferCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeExternalTransfer not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteEmployeeExternalTransferCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeExternalTransfer not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}