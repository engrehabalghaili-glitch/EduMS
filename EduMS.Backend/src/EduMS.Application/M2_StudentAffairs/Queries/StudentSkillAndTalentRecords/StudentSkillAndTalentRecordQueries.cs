using EduMS.Application.M2_StudentAffairs.DTOs.StudentSkillAndTalentRecords;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentSkillAndTalentRecords;

public class GetStudentSkillAndTalentRecordByIdQuery : IRequest<StudentSkillAndTalentRecordDto>
{
    public long Id { get; set; }
}

public class GetAllStudentSkillAndTalentRecordsQuery : IRequest<IEnumerable<StudentSkillAndTalentRecordDto>>
{
}