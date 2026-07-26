using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentDisciplinaryHistories;

public class StudentDisciplinaryHistoryQueryHandlers : 
    IRequestHandler<GetStudentDisciplinaryHistoryByIdQuery, StudentDisciplinaryHistoryDto>,
    IRequestHandler<GetAllStudentDisciplinaryHistoriesQuery, IEnumerable<StudentDisciplinaryHistoryDto>>
{
    private readonly IGenericRepository<StudentDisciplinaryHistory> _repository;
    private readonly IMapper _mapper;

    public StudentDisciplinaryHistoryQueryHandlers(IGenericRepository<StudentDisciplinaryHistory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentDisciplinaryHistoryDto> Handle(GetStudentDisciplinaryHistoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentDisciplinaryHistory not found.");
        return _mapper.Map<StudentDisciplinaryHistoryDto>(entity);
    }

    public async Task<IEnumerable<StudentDisciplinaryHistoryDto>> Handle(GetAllStudentDisciplinaryHistoriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentDisciplinaryHistoryDto>>(entities);
    }
}