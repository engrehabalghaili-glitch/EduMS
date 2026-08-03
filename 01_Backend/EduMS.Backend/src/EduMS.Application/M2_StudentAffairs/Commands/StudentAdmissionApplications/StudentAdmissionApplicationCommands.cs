using EduMS.Application.M2_StudentAffairs.DTOs.StudentAdmissionApplications;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAdmissionApplications;

public class CreateStudentAdmissionApplicationCommand : IRequest<long>
{
    public CreateStudentAdmissionApplicationDto Dto { get; set; } = new();
}

public class UpdateStudentAdmissionApplicationCommand : IRequest<bool>
{
    public UpdateStudentAdmissionApplicationDto Dto { get; set; } = new();
}

public class DeleteStudentAdmissionApplicationCommand : IRequest<bool>
{
    public long Id { get; set; }
}