using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentAcademicPermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentAcademicPermissions;

public class StudentAcademicPermissionQueryHandlers : 
    IRequestHandler<GetStudentAcademicPermissionByIdQuery, StudentAcademicPermissionDto>,
    IRequestHandler<GetAllStudentAcademicPermissionsQuery, IEnumerable<StudentAcademicPermissionDto>>
{
    private readonly IGenericRepository<StudentAcademicPermission> _repository;
    private readonly IMapper _mapper;

    public StudentAcademicPermissionQueryHandlers(IGenericRepository<StudentAcademicPermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentAcademicPermissionDto> Handle(GetStudentAcademicPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAcademicPermission not found.");
        return _mapper.Map<StudentAcademicPermissionDto>(entity);
    }

    public async Task<IEnumerable<StudentAcademicPermissionDto>> Handle(GetAllStudentAcademicPermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentAcademicPermissionDto>>(entities);
    }
}