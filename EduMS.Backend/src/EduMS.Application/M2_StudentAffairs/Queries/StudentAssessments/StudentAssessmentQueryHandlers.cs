using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssessments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAssessments;

public class StudentAssessmentQueryHandlers : 
    IRequestHandler<GetStudentAssessmentByIdQuery, StudentAssessmentDto>,
    IRequestHandler<GetAllStudentAssessmentsQuery, IEnumerable<StudentAssessmentDto>>
{
    private readonly IGenericRepository<StudentAssessment> _repository;
    private readonly IMapper _mapper;

    public StudentAssessmentQueryHandlers(IGenericRepository<StudentAssessment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentAssessmentDto> Handle(GetStudentAssessmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAssessment not found.");
        return _mapper.Map<StudentAssessmentDto>(entity);
    }

    public async Task<IEnumerable<StudentAssessmentDto>> Handle(GetAllStudentAssessmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentAssessmentDto>>(entities);
    }
}