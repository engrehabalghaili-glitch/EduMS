using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssignmentSubmissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAssignmentSubmissions;

public class StudentAssignmentSubmissionQueryHandlers : 
    IRequestHandler<GetStudentAssignmentSubmissionByIdQuery, StudentAssignmentSubmissionDto>,
    IRequestHandler<GetAllStudentAssignmentSubmissionsQuery, IEnumerable<StudentAssignmentSubmissionDto>>
{
    private readonly IGenericRepository<StudentAssignmentSubmission> _repository;
    private readonly IMapper _mapper;

    public StudentAssignmentSubmissionQueryHandlers(IGenericRepository<StudentAssignmentSubmission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentAssignmentSubmissionDto> Handle(GetStudentAssignmentSubmissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAssignmentSubmission not found.");
        return _mapper.Map<StudentAssignmentSubmissionDto>(entity);
    }

    public async Task<IEnumerable<StudentAssignmentSubmissionDto>> Handle(GetAllStudentAssignmentSubmissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentAssignmentSubmissionDto>>(entities);
    }
}