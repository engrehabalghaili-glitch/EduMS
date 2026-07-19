using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.SchoolStatisticsDrafts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.SchoolStatisticsDrafts;

public class SchoolStatisticsDraftQueryHandlers : 
    IRequestHandler<CalculateLiveSchoolStatisticsDraftQuery, string>,
    IRequestHandler<GetSchoolStatisticsDraftSnapshotQuery, SchoolStatisticsDraftDto>
{
    private readonly IGenericRepository<SchoolStatisticsDraft> _repository;
    private readonly IMapper _mapper;

    public SchoolStatisticsDraftQueryHandlers(IGenericRepository<SchoolStatisticsDraft> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveSchoolStatisticsDraftQuery request, CancellationToken cancellationToken)
    {
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<SchoolStatisticsDraftDto> Handle(GetSchoolStatisticsDraftSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolStatisticsDraft snapshot not found.");
        return _mapper.Map<SchoolStatisticsDraftDto>(entity);
    }
}