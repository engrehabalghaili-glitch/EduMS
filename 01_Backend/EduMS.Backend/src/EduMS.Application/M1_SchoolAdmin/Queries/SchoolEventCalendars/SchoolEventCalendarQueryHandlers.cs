using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolEventCalendars;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolEventCalendars;

public class SchoolEventCalendarQueryHandlers : 
    IRequestHandler<GetSchoolEventCalendarByIdQuery, SchoolEventCalendarDto>,
    IRequestHandler<GetAllSchoolEventCalendarsQuery, IEnumerable<SchoolEventCalendarDto>>
{
    private readonly IGenericRepository<SchoolEventCalendar> _repository;
    private readonly IMapper _mapper;

    public SchoolEventCalendarQueryHandlers(IGenericRepository<SchoolEventCalendar> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolEventCalendarDto> Handle(GetSchoolEventCalendarByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolEventCalendar not found.");
        return _mapper.Map<SchoolEventCalendarDto>(entity);
    }

    public async Task<IEnumerable<SchoolEventCalendarDto>> Handle(GetAllSchoolEventCalendarsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolEventCalendarDto>>(entities);
    }
}