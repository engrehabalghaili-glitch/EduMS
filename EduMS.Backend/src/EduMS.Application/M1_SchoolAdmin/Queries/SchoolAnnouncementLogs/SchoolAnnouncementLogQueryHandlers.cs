using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAnnouncementLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAnnouncementLogs;

public class SchoolAnnouncementLogQueryHandlers : 
    IRequestHandler<GetSchoolAnnouncementLogByIdQuery, SchoolAnnouncementLogDto>,
    IRequestHandler<GetAllSchoolAnnouncementLogsQuery, IEnumerable<SchoolAnnouncementLogDto>>
{
    private readonly IGenericRepository<SchoolAnnouncementLog> _repository;
    private readonly IMapper _mapper;

    public SchoolAnnouncementLogQueryHandlers(IGenericRepository<SchoolAnnouncementLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolAnnouncementLogDto> Handle(GetSchoolAnnouncementLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolAnnouncementLog not found.");
        return _mapper.Map<SchoolAnnouncementLogDto>(entity);
    }

    public async Task<IEnumerable<SchoolAnnouncementLogDto>> Handle(GetAllSchoolAnnouncementLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolAnnouncementLogDto>>(entities);
    }
}