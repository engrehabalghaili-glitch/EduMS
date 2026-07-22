using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTerminations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeTerminations;

public class EmployeeTerminationQueryHandlers : 
    IRequestHandler<GetEmployeeTerminationByIdQuery, EmployeeTerminationDto>,
    IRequestHandler<GetAllEmployeeTerminationsQuery, IEnumerable<EmployeeTerminationDto>>
{
    private readonly IGenericRepository<EmployeeTermination> _repository;
    private readonly IMapper _mapper;

    public EmployeeTerminationQueryHandlers(IGenericRepository<EmployeeTermination> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeTerminationDto> Handle(GetEmployeeTerminationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeTermination not found.");
        return _mapper.Map<EmployeeTerminationDto>(entity);
    }

    public async Task<IEnumerable<EmployeeTerminationDto>> Handle(GetAllEmployeeTerminationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeTerminationDto>>(entities);
    }
}