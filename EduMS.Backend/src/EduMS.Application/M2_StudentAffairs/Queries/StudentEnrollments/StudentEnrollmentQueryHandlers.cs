using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentEnrollments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentEnrollments;

public class StudentEnrollmentQueryHandlers : 
    IRequestHandler<GetStudentEnrollmentByIdQuery, StudentEnrollmentDto>,
    IRequestHandler<GetAllStudentEnrollmentsQuery, IEnumerable<StudentEnrollmentDto>>
{
    private readonly IGenericRepository<StudentEnrollment> _repository;
    private readonly IMapper _mapper;

    public StudentEnrollmentQueryHandlers(IGenericRepository<StudentEnrollment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentEnrollmentDto> Handle(GetStudentEnrollmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentEnrollment not found.");
        return _mapper.Map<StudentEnrollmentDto>(entity);
    }

    public async Task<IEnumerable<StudentEnrollmentDto>> Handle(GetAllStudentEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentEnrollmentDto>>(entities);
    }
}