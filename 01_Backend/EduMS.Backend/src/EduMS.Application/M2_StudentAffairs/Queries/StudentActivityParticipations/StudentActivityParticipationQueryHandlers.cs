using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentActivityParticipations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentActivityParticipations;

public class StudentActivityParticipationQueryHandlers : 
    IRequestHandler<GetStudentActivityParticipationByIdQuery, StudentActivityParticipationDto>,
    IRequestHandler<GetAllStudentActivityParticipationsQuery, IEnumerable<StudentActivityParticipationDto>>
{
    private readonly IGenericRepository<StudentActivityParticipation> _repository;
    private readonly IMapper _mapper;

    public StudentActivityParticipationQueryHandlers(IGenericRepository<StudentActivityParticipation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentActivityParticipationDto> Handle(GetStudentActivityParticipationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentActivityParticipation not found.");
        return _mapper.Map<StudentActivityParticipationDto>(entity);
    }

    public async Task<IEnumerable<StudentActivityParticipationDto>> Handle(GetAllStudentActivityParticipationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentActivityParticipationDto>>(entities);
    }
}