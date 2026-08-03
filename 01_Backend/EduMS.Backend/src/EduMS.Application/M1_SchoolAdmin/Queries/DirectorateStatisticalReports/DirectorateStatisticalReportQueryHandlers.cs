using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateStatisticalReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.DirectorateStatisticalReports;

public class DirectorateStatisticalReportQueryHandlers : 
    IRequestHandler<GetDirectorateStatisticalReportByIdQuery, DirectorateStatisticalReportDto>,
    IRequestHandler<GetAllDirectorateStatisticalReportsQuery, IEnumerable<DirectorateStatisticalReportDto>>
{
    private readonly IGenericRepository<DirectorateStatisticalReport> _repository;
    private readonly IMapper _mapper;

    public DirectorateStatisticalReportQueryHandlers(IGenericRepository<DirectorateStatisticalReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DirectorateStatisticalReportDto> Handle(GetDirectorateStatisticalReportByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DirectorateStatisticalReport not found.");
        return _mapper.Map<DirectorateStatisticalReportDto>(entity);
    }

    public async Task<IEnumerable<DirectorateStatisticalReportDto>> Handle(GetAllDirectorateStatisticalReportsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DirectorateStatisticalReportDto>>(entities);
    }
}