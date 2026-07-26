using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInternalTransfers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeInternalTransfers;

public class EmployeeInternalTransferQueryHandlers : 
    IRequestHandler<GetEmployeeInternalTransferByIdQuery, EmployeeInternalTransferDto>,
    IRequestHandler<GetAllEmployeeInternalTransfersQuery, IEnumerable<EmployeeInternalTransferDto>>
{
    private readonly IGenericRepository<EmployeeInternalTransfer> _repository;
    private readonly IMapper _mapper;

    public EmployeeInternalTransferQueryHandlers(IGenericRepository<EmployeeInternalTransfer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeInternalTransferDto> Handle(GetEmployeeInternalTransferByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeInternalTransfer not found.");
        return _mapper.Map<EmployeeInternalTransferDto>(entity);
    }

    public async Task<IEnumerable<EmployeeInternalTransferDto>> Handle(GetAllEmployeeInternalTransfersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeInternalTransferDto>>(entities);
    }
}