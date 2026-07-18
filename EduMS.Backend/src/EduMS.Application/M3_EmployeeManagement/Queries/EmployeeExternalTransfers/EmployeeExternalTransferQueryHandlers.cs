using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeExternalTransfers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeExternalTransfers;

public class EmployeeExternalTransferQueryHandlers : 
    IRequestHandler<GetEmployeeExternalTransferByIdQuery, EmployeeExternalTransferDto>,
    IRequestHandler<GetAllEmployeeExternalTransfersQuery, IEnumerable<EmployeeExternalTransferDto>>
{
    private readonly IGenericRepository<EmployeeExternalTransfer> _repository;
    private readonly IMapper _mapper;

    public EmployeeExternalTransferQueryHandlers(IGenericRepository<EmployeeExternalTransfer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeExternalTransferDto> Handle(GetEmployeeExternalTransferByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeExternalTransfer not found.");
        return _mapper.Map<EmployeeExternalTransferDto>(entity);
    }

    public async Task<IEnumerable<EmployeeExternalTransferDto>> Handle(GetAllEmployeeExternalTransfersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeExternalTransferDto>>(entities);
    }
}