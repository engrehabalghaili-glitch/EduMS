using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAccreditationLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAccreditationLogs;

public class SchoolAccreditationLogQueryHandlers : 
    IRequestHandler<GetSchoolAccreditationLogByIdQuery, SchoolAccreditationLogDto>,
    IRequestHandler<GetAllSchoolAccreditationLogsQuery, IEnumerable<SchoolAccreditationLogDto>>
{
    private readonly IGenericRepository<SchoolAccreditationLog> _repository;
    private readonly IMapper _mapper;

    public SchoolAccreditationLogQueryHandlers(IGenericRepository<SchoolAccreditationLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolAccreditationLogDto> Handle(GetSchoolAccreditationLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolAccreditationLog not found.");
        return _mapper.Map<SchoolAccreditationLogDto>(entity);
    }

    public async Task<IEnumerable<SchoolAccreditationLogDto>> Handle(GetAllSchoolAccreditationLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolAccreditationLogDto>>(entities);
    }
}