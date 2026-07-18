using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.Classrooms;

public class ClassroomQueryHandlers : 
    IRequestHandler<GetClassroomByIdQuery, ClassroomDto>,
    IRequestHandler<GetAllClassroomsQuery, IEnumerable<ClassroomDto>>
{
    private readonly IGenericRepository<Classroom> _repository;
    private readonly IMapper _mapper;

    public ClassroomQueryHandlers(IGenericRepository<Classroom> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClassroomDto> Handle(GetClassroomByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Classroom not found.");
        return _mapper.Map<ClassroomDto>(entity);
    }

    public async Task<IEnumerable<ClassroomDto>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ClassroomDto>>(entities);
    }
}