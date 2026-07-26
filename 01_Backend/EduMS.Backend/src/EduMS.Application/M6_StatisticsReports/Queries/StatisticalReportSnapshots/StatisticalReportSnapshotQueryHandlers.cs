using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.StatisticalReportSnapshots;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.StatisticalReportSnapshots;

public class StatisticalReportSnapshotQueryHandlers : 
    IRequestHandler<GetStatisticalReportSnapshotByIdQuery, StatisticalReportSnapshotDto>,
    IRequestHandler<GetAllStatisticalReportSnapshotsQuery, IEnumerable<StatisticalReportSnapshotDto>>
{
    private readonly IGenericRepository<StatisticalReportSnapshot> _repository;
    private readonly IMapper _mapper;

    public StatisticalReportSnapshotQueryHandlers(IGenericRepository<StatisticalReportSnapshot> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StatisticalReportSnapshotDto> Handle(GetStatisticalReportSnapshotByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StatisticalReportSnapshot not found.");
        return _mapper.Map<StatisticalReportSnapshotDto>(entity);
    }

    public async Task<IEnumerable<StatisticalReportSnapshotDto>> Handle(GetAllStatisticalReportSnapshotsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StatisticalReportSnapshotDto>>(entities);
    }
}