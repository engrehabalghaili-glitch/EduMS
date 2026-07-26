using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentDailyAttendanceSummaries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentDailyAttendanceSummaries;

public class StudentDailyAttendanceSummaryQueryHandlers : 
    IRequestHandler<GetStudentDailyAttendanceSummaryByIdQuery, StudentDailyAttendanceSummaryDto>,
    IRequestHandler<GetAllStudentDailyAttendanceSummariesQuery, IEnumerable<StudentDailyAttendanceSummaryDto>>
{
    private readonly IGenericRepository<StudentDailyAttendanceSummary> _repository;
    private readonly IMapper _mapper;

    public StudentDailyAttendanceSummaryQueryHandlers(IGenericRepository<StudentDailyAttendanceSummary> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentDailyAttendanceSummaryDto> Handle(GetStudentDailyAttendanceSummaryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentDailyAttendanceSummary not found.");
        return _mapper.Map<StudentDailyAttendanceSummaryDto>(entity);
    }

    public async Task<IEnumerable<StudentDailyAttendanceSummaryDto>> Handle(GetAllStudentDailyAttendanceSummariesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentDailyAttendanceSummaryDto>>(entities);
    }
}