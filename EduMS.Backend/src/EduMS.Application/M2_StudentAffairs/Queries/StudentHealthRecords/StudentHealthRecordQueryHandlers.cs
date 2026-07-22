using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentHealthRecords;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentHealthRecords;

public class StudentHealthRecordQueryHandlers : 
    IRequestHandler<GetStudentHealthRecordByIdQuery, StudentHealthRecordDto>,
    IRequestHandler<GetAllStudentHealthRecordsQuery, IEnumerable<StudentHealthRecordDto>>
{
    private readonly IGenericRepository<StudentHealthRecord> _repository;
    private readonly IMapper _mapper;

    public StudentHealthRecordQueryHandlers(IGenericRepository<StudentHealthRecord> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentHealthRecordDto> Handle(GetStudentHealthRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentHealthRecord not found.");
        return _mapper.Map<StudentHealthRecordDto>(entity);
    }

    public async Task<IEnumerable<StudentHealthRecordDto>> Handle(GetAllStudentHealthRecordsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentHealthRecordDto>>(entities);
    }
}