using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolOperationalBudgetLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolOperationalBudgetLogs;

public class SchoolOperationalBudgetLogQueryHandlers : 
    IRequestHandler<GetSchoolOperationalBudgetLogByIdQuery, SchoolOperationalBudgetLogDto>,
    IRequestHandler<GetAllSchoolOperationalBudgetLogsQuery, IEnumerable<SchoolOperationalBudgetLogDto>>
{
    private readonly IGenericRepository<SchoolOperationalBudgetLog> _repository;
    private readonly IMapper _mapper;

    public SchoolOperationalBudgetLogQueryHandlers(IGenericRepository<SchoolOperationalBudgetLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolOperationalBudgetLogDto> Handle(GetSchoolOperationalBudgetLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolOperationalBudgetLog not found.");
        return _mapper.Map<SchoolOperationalBudgetLogDto>(entity);
    }

    public async Task<IEnumerable<SchoolOperationalBudgetLogDto>> Handle(GetAllSchoolOperationalBudgetLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolOperationalBudgetLogDto>>(entities);
    }
}