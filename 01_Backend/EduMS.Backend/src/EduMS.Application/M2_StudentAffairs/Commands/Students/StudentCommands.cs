using EduMS.Application.M2_StudentAffairs.DTOs.Students;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.Students;

public class CreateStudentCommand : IRequest<long>
{
    public CreateStudentDto Dto { get; set; } = new();
}

public class UpdateStudentCommand : IRequest<bool>
{
    public UpdateStudentDto Dto { get; set; } = new();
}

public class DeleteStudentCommand : IRequest<bool>
{
    public long Id { get; set; }
}