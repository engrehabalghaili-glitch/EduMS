using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.OrganizationalSectors;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.OrganizationalSectors;

public class OrganizationalSectorQueryHandlers : 
    IRequestHandler<GetOrganizationalSectorByIdQuery, OrganizationalSectorDto>,
    IRequestHandler<GetAllOrganizationalSectorsQuery, IEnumerable<OrganizationalSectorDto>>
{
    private readonly IGenericRepository<OrganizationalSector> _repository;
    private readonly IMapper _mapper;

    public OrganizationalSectorQueryHandlers(IGenericRepository<OrganizationalSector> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OrganizationalSectorDto> Handle(GetOrganizationalSectorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"OrganizationalSector not found.");
        return _mapper.Map<OrganizationalSectorDto>(entity);
    }

    public async Task<IEnumerable<OrganizationalSectorDto>> Handle(GetAllOrganizationalSectorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<OrganizationalSectorDto>>(entities);
    }
}