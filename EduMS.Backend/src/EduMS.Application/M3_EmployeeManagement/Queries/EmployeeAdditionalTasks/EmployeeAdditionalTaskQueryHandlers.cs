using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAdditionalTasks;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeAdditionalTasks;

public class EmployeeAdditionalTaskQueryHandlers : 
    IRequestHandler<GetEmployeeAdditionalTaskByIdQuery, EmployeeAdditionalTaskDto>,
    IRequestHandler<GetAllEmployeeAdditionalTasksQuery, IEnumerable<EmployeeAdditionalTaskDto>>
{
    private readonly IGenericRepository<EmployeeAdditionalTask> _repository;
    private readonly IMapper _mapper;

    public EmployeeAdditionalTaskQueryHandlers(IGenericRepository<EmployeeAdditionalTask> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeAdditionalTaskDto> Handle(GetEmployeeAdditionalTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeAdditionalTask not found.");
        return _mapper.Map<EmployeeAdditionalTaskDto>(entity);
    }

    public async Task<IEnumerable<EmployeeAdditionalTaskDto>> Handle(GetAllEmployeeAdditionalTasksQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeAdditionalTaskDto>>(entities);
    }
}