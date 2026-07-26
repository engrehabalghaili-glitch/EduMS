using EduMS.Application.M2_StudentAffairs.DTOs.StudentFinancialAidApplications;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentFinancialAidApplications;

public class CreateStudentFinancialAidApplicationCommand : IRequest<long>
{
    public CreateStudentFinancialAidApplicationDto Dto { get; set; } = new();
}

public class UpdateStudentFinancialAidApplicationCommand : IRequest<bool>
{
    public UpdateStudentFinancialAidApplicationDto Dto { get; set; } = new();
}

public class DeleteStudentFinancialAidApplicationCommand : IRequest<bool>
{
    public long Id { get; set; }
}