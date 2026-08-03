using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentPsychologicalCounselingLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentPsychologicalCounselingLogs;

public class StudentPsychologicalCounselingLogQueryHandlers : 
    IRequestHandler<GetStudentPsychologicalCounselingLogByIdQuery, StudentPsychologicalCounselingLogDto>,
    IRequestHandler<GetAllStudentPsychologicalCounselingLogsQuery, IEnumerable<StudentPsychologicalCounselingLogDto>>
{
    private readonly IGenericRepository<StudentPsychologicalCounselingLog> _repository;
    private readonly IMapper _mapper;

    public StudentPsychologicalCounselingLogQueryHandlers(IGenericRepository<StudentPsychologicalCounselingLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentPsychologicalCounselingLogDto> Handle(GetStudentPsychologicalCounselingLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentPsychologicalCounselingLog not found.");
        return _mapper.Map<StudentPsychologicalCounselingLogDto>(entity);
    }

    public async Task<IEnumerable<StudentPsychologicalCounselingLogDto>> Handle(GetAllStudentPsychologicalCounselingLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentPsychologicalCounselingLogDto>>(entities);
    }
}