using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrolls;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeePayrolls;

public class EmployeePayrollQueryHandlers : 
    IRequestHandler<GetEmployeePayrollByIdQuery, EmployeePayrollDto>,
    IRequestHandler<GetAllEmployeePayrollsQuery, IEnumerable<EmployeePayrollDto>>
{
    private readonly IGenericRepository<EmployeePayroll> _repository;
    private readonly IMapper _mapper;

    public EmployeePayrollQueryHandlers(IGenericRepository<EmployeePayroll> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeePayrollDto> Handle(GetEmployeePayrollByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeePayroll not found.");
        return _mapper.Map<EmployeePayrollDto>(entity);
    }

    public async Task<IEnumerable<EmployeePayrollDto>> Handle(GetAllEmployeePayrollsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeePayrollDto>>(entities);
    }
}