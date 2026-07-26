using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAbsenceExcusals;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAbsenceExcusals;

public class StudentAbsenceExcusalQueryHandlers : 
    IRequestHandler<GetStudentAbsenceExcusalByIdQuery, StudentAbsenceExcusalDto>,
    IRequestHandler<GetAllStudentAbsenceExcusalsQuery, IEnumerable<StudentAbsenceExcusalDto>>
{
    private readonly IGenericRepository<StudentAbsenceExcusal> _repository;
    private readonly IMapper _mapper;

    public StudentAbsenceExcusalQueryHandlers(IGenericRepository<StudentAbsenceExcusal> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentAbsenceExcusalDto> Handle(GetStudentAbsenceExcusalByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAbsenceExcusal not found.");
        return _mapper.Map<StudentAbsenceExcusalDto>(entity);
    }

    public async Task<IEnumerable<StudentAbsenceExcusalDto>> Handle(GetAllStudentAbsenceExcusalsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentAbsenceExcusalDto>>(entities);
    }
}