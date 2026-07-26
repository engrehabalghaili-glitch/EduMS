using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemplaryRecognitions;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExemplaryRecognitions;

public class CreateStudentExemplaryRecognitionCommand : IRequest<long>
{
    public CreateStudentExemplaryRecognitionDto Dto { get; set; } = new();
}

public class UpdateStudentExemplaryRecognitionCommand : IRequest<bool>
{
    public UpdateStudentExemplaryRecognitionDto Dto { get; set; } = new();
}

public class DeleteStudentExemplaryRecognitionCommand : IRequest<bool>
{
    public long Id { get; set; }
}