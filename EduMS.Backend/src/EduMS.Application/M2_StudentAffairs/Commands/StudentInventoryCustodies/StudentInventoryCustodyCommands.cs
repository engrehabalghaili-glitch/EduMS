using EduMS.Application.M2_StudentAffairs.DTOs.StudentInventoryCustodies;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentInventoryCustodies;

public class CreateStudentInventoryCustodyCommand : IRequest<long>
{
    public CreateStudentInventoryCustodyDto Dto { get; set; } = new();
}

public class UpdateStudentInventoryCustodyCommand : IRequest<bool>
{
    public UpdateStudentInventoryCustodyDto Dto { get; set; } = new();
}

public class DeleteStudentInventoryCustodyCommand : IRequest<bool>
{
    public long Id { get; set; }
}