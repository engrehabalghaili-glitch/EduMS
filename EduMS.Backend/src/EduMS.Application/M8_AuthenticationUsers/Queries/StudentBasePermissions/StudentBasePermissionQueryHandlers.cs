using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentBasePermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentBasePermissions;

public class StudentBasePermissionQueryHandlers : 
    IRequestHandler<GetStudentBasePermissionByIdQuery, StudentBasePermissionDto>,
    IRequestHandler<GetAllStudentBasePermissionsQuery, IEnumerable<StudentBasePermissionDto>>
{
    private readonly IGenericRepository<StudentBasePermission> _repository;
    private readonly IMapper _mapper;

    public StudentBasePermissionQueryHandlers(IGenericRepository<StudentBasePermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentBasePermissionDto> Handle(GetStudentBasePermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentBasePermission not found.");
        return _mapper.Map<StudentBasePermissionDto>(entity);
    }

    public async Task<IEnumerable<StudentBasePermissionDto>> Handle(GetAllStudentBasePermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentBasePermissionDto>>(entities);
    }
}