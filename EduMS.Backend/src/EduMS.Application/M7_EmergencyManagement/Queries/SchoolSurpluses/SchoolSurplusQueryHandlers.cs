using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolSurpluses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolSurpluses;

public class SchoolSurplusQueryHandlers : 
    IRequestHandler<GetSchoolSurplusByIdQuery, SchoolSurplusDto>,
    IRequestHandler<GetAllSchoolSurplusesQuery, IEnumerable<SchoolSurplusDto>>
{
    private readonly IGenericRepository<SchoolSurplus> _repository;
    private readonly IMapper _mapper;

    public SchoolSurplusQueryHandlers(IGenericRepository<SchoolSurplus> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolSurplusDto> Handle(GetSchoolSurplusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolSurplus not found.");
        return _mapper.Map<SchoolSurplusDto>(entity);
    }

    public async Task<IEnumerable<SchoolSurplusDto>> Handle(GetAllSchoolSurplusesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolSurplusDto>>(entities);
    }
}