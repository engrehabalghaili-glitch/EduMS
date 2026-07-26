using EduMS.Application.M2_StudentAffairs.DTOs.StudentMedicalAllergyLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentMedicalAllergyLogs;

public class CreateStudentMedicalAllergyLogCommand : IRequest<long>
{
    public CreateStudentMedicalAllergyLogDto Dto { get; set; } = new();
}

public class UpdateStudentMedicalAllergyLogCommand : IRequest<bool>
{
    public UpdateStudentMedicalAllergyLogDto Dto { get; set; } = new();
}

public class DeleteStudentMedicalAllergyLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}