using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.DetailedAcademicWarningLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.DetailedAcademicWarningLogs;

public class DetailedAcademicWarningLogQueryHandlers : 
    IRequestHandler<GetDetailedAcademicWarningLogByIdQuery, DetailedAcademicWarningLogDto>,
    IRequestHandler<GetAllDetailedAcademicWarningLogsQuery, IEnumerable<DetailedAcademicWarningLogDto>>
{
    private readonly IGenericRepository<DetailedAcademicWarningLog> _repository;
    private readonly IMapper _mapper;

    public DetailedAcademicWarningLogQueryHandlers(IGenericRepository<DetailedAcademicWarningLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DetailedAcademicWarningLogDto> Handle(GetDetailedAcademicWarningLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DetailedAcademicWarningLog not found.");
        return _mapper.Map<DetailedAcademicWarningLogDto>(entity);
    }

    public async Task<IEnumerable<DetailedAcademicWarningLogDto>> Handle(GetAllDetailedAcademicWarningLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DetailedAcademicWarningLogDto>>(entities);
    }
}