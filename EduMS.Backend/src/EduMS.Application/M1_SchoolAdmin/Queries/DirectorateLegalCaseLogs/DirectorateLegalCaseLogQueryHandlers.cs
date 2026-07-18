using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateLegalCaseLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.DirectorateLegalCaseLogs;

public class DirectorateLegalCaseLogQueryHandlers : 
    IRequestHandler<GetDirectorateLegalCaseLogByIdQuery, DirectorateLegalCaseLogDto>,
    IRequestHandler<GetAllDirectorateLegalCaseLogsQuery, IEnumerable<DirectorateLegalCaseLogDto>>
{
    private readonly IGenericRepository<DirectorateLegalCaseLog> _repository;
    private readonly IMapper _mapper;

    public DirectorateLegalCaseLogQueryHandlers(IGenericRepository<DirectorateLegalCaseLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DirectorateLegalCaseLogDto> Handle(GetDirectorateLegalCaseLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DirectorateLegalCaseLog not found.");
        return _mapper.Map<DirectorateLegalCaseLogDto>(entity);
    }

    public async Task<IEnumerable<DirectorateLegalCaseLogDto>> Handle(GetAllDirectorateLegalCaseLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DirectorateLegalCaseLogDto>>(entities);
    }
}