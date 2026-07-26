using EduMS.Application.M2_StudentAffairs.DTOs.ClassSections;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.ClassSections;

public class CreateClassSectionCommand : IRequest<long>
{
    public CreateClassSectionDto Dto { get; set; } = new();
}

public class UpdateClassSectionCommand : IRequest<bool>
{
    public UpdateClassSectionDto Dto { get; set; } = new();
}

public class DeleteClassSectionCommand : IRequest<bool>
{
    public long Id { get; set; }
}