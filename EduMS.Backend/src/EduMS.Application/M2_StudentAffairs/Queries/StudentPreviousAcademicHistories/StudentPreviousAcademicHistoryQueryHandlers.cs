using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentPreviousAcademicHistories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentPreviousAcademicHistories;

public class StudentPreviousAcademicHistoryQueryHandlers : 
    IRequestHandler<GetStudentPreviousAcademicHistoryByIdQuery, StudentPreviousAcademicHistoryDto>,
    IRequestHandler<GetAllStudentPreviousAcademicHistoriesQuery, IEnumerable<StudentPreviousAcademicHistoryDto>>
{
    private readonly IGenericRepository<StudentPreviousAcademicHistory> _repository;
    private readonly IMapper _mapper;

    public StudentPreviousAcademicHistoryQueryHandlers(IGenericRepository<StudentPreviousAcademicHistory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentPreviousAcademicHistoryDto> Handle(GetStudentPreviousAcademicHistoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentPreviousAcademicHistory not found.");
        return _mapper.Map<StudentPreviousAcademicHistoryDto>(entity);
    }

    public async Task<IEnumerable<StudentPreviousAcademicHistoryDto>> Handle(GetAllStudentPreviousAcademicHistoriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentPreviousAcademicHistoryDto>>(entities);
    }
}