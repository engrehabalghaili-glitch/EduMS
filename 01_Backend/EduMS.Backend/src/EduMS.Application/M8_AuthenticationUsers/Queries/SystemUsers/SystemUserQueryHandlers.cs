using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemUsers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemUsers;

public class SystemUserQueryHandlers : 
    IRequestHandler<GetSystemUserByIdQuery, SystemUserDto>,
    IRequestHandler<GetAllSystemUsersQuery, IEnumerable<SystemUserDto>>
{
    private readonly IGenericRepository<SystemUser> _repository;
    private readonly IMapper _mapper;

    public SystemUserQueryHandlers(IGenericRepository<SystemUser> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SystemUserDto> Handle(GetSystemUserByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SystemUser not found.");
        return _mapper.Map<SystemUserDto>(entity);
    }

    public async Task<IEnumerable<SystemUserDto>> Handle(GetAllSystemUsersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SystemUserDto>>(entities);
    }
}