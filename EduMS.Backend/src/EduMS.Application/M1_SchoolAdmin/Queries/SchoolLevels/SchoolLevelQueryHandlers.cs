using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLevels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolLevels;

public class SchoolLevelQueryHandlers : 
    IRequestHandler<GetSchoolLevelByIdQuery, SchoolLevelDto>,
    IRequestHandler<GetAllSchoolLevelsQuery, IEnumerable<SchoolLevelDto>>
{
    private readonly IGenericRepository<SchoolLevel> _repository;
    private readonly IMapper _mapper;

    public SchoolLevelQueryHandlers(IGenericRepository<SchoolLevel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolLevelDto> Handle(GetSchoolLevelByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolLevel not found.");
        return _mapper.Map<SchoolLevelDto>(entity);
    }

    public async Task<IEnumerable<SchoolLevelDto>> Handle(GetAllSchoolLevelsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolLevelDto>>(entities);
    }
}