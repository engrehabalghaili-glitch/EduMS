using EduMS.Application.M2_StudentAffairs.DTOs.StudentEnrollments;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentEnrollments;

public class CreateStudentEnrollmentCommand : IRequest<long>
{
    public CreateStudentEnrollmentDto Dto { get; set; } = new();
}

public class UpdateStudentEnrollmentCommand : IRequest<bool>
{
    public UpdateStudentEnrollmentDto Dto { get; set; } = new();
}

public class DeleteStudentEnrollmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}