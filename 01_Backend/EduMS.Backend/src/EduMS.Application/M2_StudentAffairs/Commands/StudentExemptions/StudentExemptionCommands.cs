using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemptions;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExemptions;

public class CreateStudentExemptionCommand : IRequest<long>
{
    public CreateStudentExemptionDto Dto { get; set; } = new();
}

public class UpdateStudentExemptionCommand : IRequest<bool>
{
    public UpdateStudentExemptionDto Dto { get; set; } = new();
}

public class DeleteStudentExemptionCommand : IRequest<bool>
{
    public long Id { get; set; }
}