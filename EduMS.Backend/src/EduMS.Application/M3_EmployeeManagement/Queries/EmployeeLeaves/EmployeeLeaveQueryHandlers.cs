using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeLeaves;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeLeaves;

public class EmployeeLeaveQueryHandlers : 
    IRequestHandler<GetEmployeeLeaveByIdQuery, EmployeeLeaveDto>,
    IRequestHandler<GetAllEmployeeLeavesQuery, IEnumerable<EmployeeLeaveDto>>
{
    private readonly IGenericRepository<EmployeeLeave> _repository;
    private readonly IMapper _mapper;

    public EmployeeLeaveQueryHandlers(IGenericRepository<EmployeeLeave> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeLeaveDto> Handle(GetEmployeeLeaveByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeLeave not found.");
        return _mapper.Map<EmployeeLeaveDto>(entity);
    }

    public async Task<IEnumerable<EmployeeLeaveDto>> Handle(GetAllEmployeeLeavesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeLeaveDto>>(entities);
    }
}