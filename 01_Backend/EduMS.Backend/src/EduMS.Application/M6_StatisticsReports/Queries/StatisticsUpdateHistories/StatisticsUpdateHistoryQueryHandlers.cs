using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsUpdateHistories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.StatisticsUpdateHistories;

public class StatisticsUpdateHistoryQueryHandlers : 
    IRequestHandler<GetStatisticsUpdateHistoryByIdQuery, StatisticsUpdateHistoryDto>,
    IRequestHandler<GetAllStatisticsUpdateHistoriesQuery, IEnumerable<StatisticsUpdateHistoryDto>>
{
    private readonly IGenericRepository<StatisticsUpdateHistory> _repository;
    private readonly IMapper _mapper;

    public StatisticsUpdateHistoryQueryHandlers(IGenericRepository<StatisticsUpdateHistory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StatisticsUpdateHistoryDto> Handle(GetStatisticsUpdateHistoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StatisticsUpdateHistory not found.");
        return _mapper.Map<StatisticsUpdateHistoryDto>(entity);
    }

    public async Task<IEnumerable<StatisticsUpdateHistoryDto>> Handle(GetAllStatisticsUpdateHistoriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StatisticsUpdateHistoryDto>>(entities);
    }
}