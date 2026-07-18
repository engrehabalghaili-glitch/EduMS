using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeCommittees;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeCommittees;

public class EmployeeCommitteeQueryHandlers : 
    IRequestHandler<GetEmployeeCommitteeByIdQuery, EmployeeCommitteeDto>,
    IRequestHandler<GetAllEmployeeCommitteesQuery, IEnumerable<EmployeeCommitteeDto>>
{
    private readonly IGenericRepository<EmployeeCommittee> _repository;
    private readonly IMapper _mapper;

    public EmployeeCommitteeQueryHandlers(IGenericRepository<EmployeeCommittee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeCommitteeDto> Handle(GetEmployeeCommitteeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeCommittee not found.");
        return _mapper.Map<EmployeeCommitteeDto>(entity);
    }

    public async Task<IEnumerable<EmployeeCommitteeDto>> Handle(GetAllEmployeeCommitteesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeCommitteeDto>>(entities);
    }
}