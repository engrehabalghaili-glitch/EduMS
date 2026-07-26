using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAttendances;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeAttendances;

public class EmployeeAttendanceQueryHandlers : 
    IRequestHandler<GetEmployeeAttendanceByIdQuery, EmployeeAttendanceDto>,
    IRequestHandler<GetAllEmployeeAttendancesQuery, IEnumerable<EmployeeAttendanceDto>>
{
    private readonly IGenericRepository<EmployeeAttendance> _repository;
    private readonly IMapper _mapper;

    public EmployeeAttendanceQueryHandlers(IGenericRepository<EmployeeAttendance> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeAttendanceDto> Handle(GetEmployeeAttendanceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeAttendance not found.");
        return _mapper.Map<EmployeeAttendanceDto>(entity);
    }

    public async Task<IEnumerable<EmployeeAttendanceDto>> Handle(GetAllEmployeeAttendancesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeAttendanceDto>>(entities);
    }
}