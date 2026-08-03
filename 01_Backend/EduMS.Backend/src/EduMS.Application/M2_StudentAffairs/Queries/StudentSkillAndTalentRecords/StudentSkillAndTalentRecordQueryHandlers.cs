using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentSkillAndTalentRecords;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentSkillAndTalentRecords;

public class StudentSkillAndTalentRecordQueryHandlers : 
    IRequestHandler<GetStudentSkillAndTalentRecordByIdQuery, StudentSkillAndTalentRecordDto>,
    IRequestHandler<GetAllStudentSkillAndTalentRecordsQuery, IEnumerable<StudentSkillAndTalentRecordDto>>
{
    private readonly IGenericRepository<StudentSkillAndTalentRecord> _repository;
    private readonly IMapper _mapper;

    public StudentSkillAndTalentRecordQueryHandlers(IGenericRepository<StudentSkillAndTalentRecord> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentSkillAndTalentRecordDto> Handle(GetStudentSkillAndTalentRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentSkillAndTalentRecord not found.");
        return _mapper.Map<StudentSkillAndTalentRecordDto>(entity);
    }

    public async Task<IEnumerable<StudentSkillAndTalentRecordDto>> Handle(GetAllStudentSkillAndTalentRecordsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentSkillAndTalentRecordDto>>(entities);
    }
}