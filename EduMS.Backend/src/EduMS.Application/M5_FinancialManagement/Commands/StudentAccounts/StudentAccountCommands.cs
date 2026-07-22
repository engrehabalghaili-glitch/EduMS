using EduMS.Application.M5_FinancialManagement.DTOs.StudentAccounts;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.StudentAccounts;

public class CreateStudentAccountCommand : IRequest<long>
{
    public CreateStudentAccountDto Dto { get; set; } = new();
}

public class UpdateStudentAccountCommand : IRequest<bool>
{
    public UpdateStudentAccountDto Dto { get; set; } = new();
}

public class DeleteStudentAccountCommand : IRequest<bool>
{
    public long Id { get; set; }
}