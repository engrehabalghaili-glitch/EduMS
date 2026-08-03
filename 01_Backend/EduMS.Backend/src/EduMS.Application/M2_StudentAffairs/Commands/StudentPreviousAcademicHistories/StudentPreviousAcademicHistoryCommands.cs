using EduMS.Application.M2_StudentAffairs.DTOs.StudentPreviousAcademicHistories;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentPreviousAcademicHistories;

public class CreateStudentPreviousAcademicHistoryCommand : IRequest<long>
{
    public CreateStudentPreviousAcademicHistoryDto Dto { get; set; } = new();
}

public class UpdateStudentPreviousAcademicHistoryCommand : IRequest<bool>
{
    public UpdateStudentPreviousAcademicHistoryDto Dto { get; set; } = new();
}

public class DeleteStudentPreviousAcademicHistoryCommand : IRequest<bool>
{
    public long Id { get; set; }
}