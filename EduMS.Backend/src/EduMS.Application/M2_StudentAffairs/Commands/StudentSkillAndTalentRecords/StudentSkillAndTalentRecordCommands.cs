using EduMS.Application.M2_StudentAffairs.DTOs.StudentSkillAndTalentRecords;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentSkillAndTalentRecords;

public class CreateStudentSkillAndTalentRecordCommand : IRequest<long>
{
    public CreateStudentSkillAndTalentRecordDto Dto { get; set; } = new();
}

public class UpdateStudentSkillAndTalentRecordCommand : IRequest<bool>
{
    public UpdateStudentSkillAndTalentRecordDto Dto { get; set; } = new();
}

public class DeleteStudentSkillAndTalentRecordCommand : IRequest<bool>
{
    public long Id { get; set; }
}