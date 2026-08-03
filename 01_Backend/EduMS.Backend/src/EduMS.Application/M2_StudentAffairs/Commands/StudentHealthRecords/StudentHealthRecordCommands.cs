using EduMS.Application.M2_StudentAffairs.DTOs.StudentHealthRecords;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentHealthRecords;

public class CreateStudentHealthRecordCommand : IRequest<long>
{
    public CreateStudentHealthRecordDto Dto { get; set; } = new();
}

public class UpdateStudentHealthRecordCommand : IRequest<bool>
{
    public UpdateStudentHealthRecordDto Dto { get; set; } = new();
}

public class DeleteStudentHealthRecordCommand : IRequest<bool>
{
    public long Id { get; set; }
}