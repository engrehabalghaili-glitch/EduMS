using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentFinancePermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentFinancePermissions;

public class StudentFinancePermissionQueryHandlers : 
    IRequestHandler<GetStudentFinancePermissionByIdQuery, StudentFinancePermissionDto>,
    IRequestHandler<GetAllStudentFinancePermissionsQuery, IEnumerable<StudentFinancePermissionDto>>
{
    private readonly IGenericRepository<StudentFinancePermission> _repository;
    private readonly IMapper _mapper;

    public StudentFinancePermissionQueryHandlers(IGenericRepository<StudentFinancePermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentFinancePermissionDto> Handle(GetStudentFinancePermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentFinancePermission not found.");
        return _mapper.Map<StudentFinancePermissionDto>(entity);
    }

    public async Task<IEnumerable<StudentFinancePermissionDto>> Handle(GetAllStudentFinancePermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentFinancePermissionDto>>(entities);
    }
}