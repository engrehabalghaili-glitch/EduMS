using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentPermissionAuditLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentPermissionAuditLogs;

public class StudentPermissionAuditLogQueryHandlers : 
    IRequestHandler<GetStudentPermissionAuditLogByIdQuery, StudentPermissionAuditLogDto>,
    IRequestHandler<GetAllStudentPermissionAuditLogsQuery, IEnumerable<StudentPermissionAuditLogDto>>
{
    private readonly IGenericRepository<StudentPermissionAuditLog> _repository;
    private readonly IMapper _mapper;

    public StudentPermissionAuditLogQueryHandlers(IGenericRepository<StudentPermissionAuditLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentPermissionAuditLogDto> Handle(GetStudentPermissionAuditLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentPermissionAuditLog not found.");
        return _mapper.Map<StudentPermissionAuditLogDto>(entity);
    }

    public async Task<IEnumerable<StudentPermissionAuditLogDto>> Handle(GetAllStudentPermissionAuditLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentPermissionAuditLogDto>>(entities);
    }
}