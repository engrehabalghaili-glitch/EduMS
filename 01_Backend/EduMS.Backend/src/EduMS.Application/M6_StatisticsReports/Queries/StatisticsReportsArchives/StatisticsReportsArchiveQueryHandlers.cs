using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsReportsArchives;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.StatisticsReportsArchives;

public class StatisticsReportsArchiveQueryHandlers : 
    IRequestHandler<GetStatisticsReportsArchiveByIdQuery, StatisticsReportsArchiveDto>,
    IRequestHandler<GetAllStatisticsReportsArchivesQuery, IEnumerable<StatisticsReportsArchiveDto>>
{
    private readonly IGenericRepository<StatisticsReportsArchive> _repository;
    private readonly IMapper _mapper;

    public StatisticsReportsArchiveQueryHandlers(IGenericRepository<StatisticsReportsArchive> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StatisticsReportsArchiveDto> Handle(GetStatisticsReportsArchiveByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StatisticsReportsArchive not found.");
        return _mapper.Map<StatisticsReportsArchiveDto>(entity);
    }

    public async Task<IEnumerable<StatisticsReportsArchiveDto>> Handle(GetAllStatisticsReportsArchivesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StatisticsReportsArchiveDto>>(entities);
    }
}