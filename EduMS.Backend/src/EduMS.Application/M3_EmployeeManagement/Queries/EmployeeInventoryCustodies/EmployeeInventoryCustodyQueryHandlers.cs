using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInventoryCustodies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeInventoryCustodies;

public class EmployeeInventoryCustodyQueryHandlers : 
    IRequestHandler<GetEmployeeInventoryCustodyByIdQuery, EmployeeInventoryCustodyDto>,
    IRequestHandler<GetAllEmployeeInventoryCustodiesQuery, IEnumerable<EmployeeInventoryCustodyDto>>
{
    private readonly IGenericRepository<EmployeeInventoryCustody> _repository;
    private readonly IMapper _mapper;

    public EmployeeInventoryCustodyQueryHandlers(IGenericRepository<EmployeeInventoryCustody> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeInventoryCustodyDto> Handle(GetEmployeeInventoryCustodyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeInventoryCustody not found.");
        return _mapper.Map<EmployeeInventoryCustodyDto>(entity);
    }

    public async Task<IEnumerable<EmployeeInventoryCustodyDto>> Handle(GetAllEmployeeInventoryCustodiesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeInventoryCustodyDto>>(entities);
    }
}