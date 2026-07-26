using EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentDisciplinaryHistories;

public class CreateStudentDisciplinaryHistoryCommand : IRequest<long>
{
    public CreateStudentDisciplinaryHistoryDto Dto { get; set; } = new();
}

public class UpdateStudentDisciplinaryHistoryCommand : IRequest<bool>
{
    public UpdateStudentDisciplinaryHistoryDto Dto { get; set; } = new();
}

public class DeleteStudentDisciplinaryHistoryCommand : IRequest<bool>
{
    public long Id { get; set; }
}