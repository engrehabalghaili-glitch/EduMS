using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.TeacherSchedules;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.TeacherSchedules;

public class TeacherScheduleQueryHandlers : 
    IRequestHandler<GetTeacherScheduleByIdQuery, TeacherScheduleDto>,
    IRequestHandler<GetAllTeacherSchedulesQuery, IEnumerable<TeacherScheduleDto>>
{
    private readonly IGenericRepository<TeacherSchedule> _repository;
    private readonly IMapper _mapper;

    public TeacherScheduleQueryHandlers(IGenericRepository<TeacherSchedule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TeacherScheduleDto> Handle(GetTeacherScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"TeacherSchedule not found.");
        return _mapper.Map<TeacherScheduleDto>(entity);
    }

    public async Task<IEnumerable<TeacherScheduleDto>> Handle(GetAllTeacherSchedulesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<TeacherScheduleDto>>(entities);
    }
}