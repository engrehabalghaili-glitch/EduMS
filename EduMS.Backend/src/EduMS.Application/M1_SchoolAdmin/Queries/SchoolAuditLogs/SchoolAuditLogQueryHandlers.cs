using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAuditLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAuditLogs;

public class SchoolAuditLogQueryHandlers : 
    IRequestHandler<GetSchoolAuditLogByIdQuery, SchoolAuditLogDto>,
    IRequestHandler<GetAllSchoolAuditLogsQuery, IEnumerable<SchoolAuditLogDto>>
{
    private readonly IGenericRepository<SchoolAuditLog> _repository;
    private readonly IMapper _mapper;

    public SchoolAuditLogQueryHandlers(IGenericRepository<SchoolAuditLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolAuditLogDto> Handle(GetSchoolAuditLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolAuditLog not found.");
        return _mapper.Map<SchoolAuditLogDto>(entity);
    }

    public async Task<IEnumerable<SchoolAuditLogDto>> Handle(GetAllSchoolAuditLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolAuditLogDto>>(entities);
    }
}