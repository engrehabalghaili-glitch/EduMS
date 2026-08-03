using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassSchedules;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ClassSchedules;

public class ClassScheduleQueryHandlers : 
    IRequestHandler<GetClassScheduleByIdQuery, ClassScheduleDto>,
    IRequestHandler<GetAllClassSchedulesQuery, IEnumerable<ClassScheduleDto>>
{
    private readonly IGenericRepository<ClassSchedule> _repository;
    private readonly IMapper _mapper;

    public ClassScheduleQueryHandlers(IGenericRepository<ClassSchedule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClassScheduleDto> Handle(GetClassScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassSchedule not found.");
        return _mapper.Map<ClassScheduleDto>(entity);
    }

    public async Task<IEnumerable<ClassScheduleDto>> Handle(GetAllClassSchedulesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ClassScheduleDto>>(entities);
    }
}