using EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Subjects;

public class CreateSubjectCommand : IRequest<long>
{
    public CreateSubjectDto Dto { get; set; } = new();
}

public class UpdateSubjectCommand : IRequest<bool>
{
    public UpdateSubjectDto Dto { get; set; } = new();
}

public class DeleteSubjectCommand : IRequest<bool>
{
    public long Id { get; set; }
}