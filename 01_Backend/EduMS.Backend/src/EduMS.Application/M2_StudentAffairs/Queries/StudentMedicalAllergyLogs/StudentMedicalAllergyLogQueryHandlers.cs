using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentMedicalAllergyLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentMedicalAllergyLogs;

public class StudentMedicalAllergyLogQueryHandlers : 
    IRequestHandler<GetStudentMedicalAllergyLogByIdQuery, StudentMedicalAllergyLogDto>,
    IRequestHandler<GetAllStudentMedicalAllergyLogsQuery, IEnumerable<StudentMedicalAllergyLogDto>>
{
    private readonly IGenericRepository<StudentMedicalAllergyLog> _repository;
    private readonly IMapper _mapper;

    public StudentMedicalAllergyLogQueryHandlers(IGenericRepository<StudentMedicalAllergyLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentMedicalAllergyLogDto> Handle(GetStudentMedicalAllergyLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentMedicalAllergyLog not found.");
        return _mapper.Map<StudentMedicalAllergyLogDto>(entity);
    }

    public async Task<IEnumerable<StudentMedicalAllergyLogDto>> Handle(GetAllStudentMedicalAllergyLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentMedicalAllergyLogDto>>(entities);
    }
}