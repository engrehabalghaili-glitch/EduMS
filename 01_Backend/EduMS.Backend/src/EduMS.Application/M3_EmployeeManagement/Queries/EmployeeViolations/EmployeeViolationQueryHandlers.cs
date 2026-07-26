using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeViolations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeViolations;

public class EmployeeViolationQueryHandlers : 
    IRequestHandler<GetEmployeeViolationByIdQuery, EmployeeViolationDto>,
    IRequestHandler<GetAllEmployeeViolationsQuery, IEnumerable<EmployeeViolationDto>>
{
    private readonly IGenericRepository<EmployeeViolation> _repository;
    private readonly IMapper _mapper;

    public EmployeeViolationQueryHandlers(IGenericRepository<EmployeeViolation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeViolationDto> Handle(GetEmployeeViolationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeViolation not found.");
        return _mapper.Map<EmployeeViolationDto>(entity);
    }

    public async Task<IEnumerable<EmployeeViolationDto>> Handle(GetAllEmployeeViolationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeViolationDto>>(entities);
    }
}