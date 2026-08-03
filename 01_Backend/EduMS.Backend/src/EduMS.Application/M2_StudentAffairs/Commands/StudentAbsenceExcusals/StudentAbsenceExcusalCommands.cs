using EduMS.Application.M2_StudentAffairs.DTOs.StudentAbsenceExcusals;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAbsenceExcusals;

public class CreateStudentAbsenceExcusalCommand : IRequest<long>
{
    public CreateStudentAbsenceExcusalDto Dto { get; set; } = new();
}

public class UpdateStudentAbsenceExcusalCommand : IRequest<bool>
{
    public UpdateStudentAbsenceExcusalDto Dto { get; set; } = new();
}

public class DeleteStudentAbsenceExcusalCommand : IRequest<bool>
{
    public long Id { get; set; }
}