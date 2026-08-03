using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.UserActivityLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.UserActivityLogs;

public class UserActivityLogQueryHandlers : 
    IRequestHandler<GetUserActivityLogByIdQuery, UserActivityLogDto>,
    IRequestHandler<GetAllUserActivityLogsQuery, IEnumerable<UserActivityLogDto>>
{
    private readonly IGenericRepository<UserActivityLog> _repository;
    private readonly IMapper _mapper;

    public UserActivityLogQueryHandlers(IGenericRepository<UserActivityLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserActivityLogDto> Handle(GetUserActivityLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"UserActivityLog not found.");
        return _mapper.Map<UserActivityLogDto>(entity);
    }

    public async Task<IEnumerable<UserActivityLogDto>> Handle(GetAllUserActivityLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserActivityLogDto>>(entities);
    }
}