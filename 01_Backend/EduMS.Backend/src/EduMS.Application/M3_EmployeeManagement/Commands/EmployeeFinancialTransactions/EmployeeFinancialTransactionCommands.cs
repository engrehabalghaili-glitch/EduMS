using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeFinancialTransactions;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeFinancialTransactions;

public class CreateEmployeeFinancialTransactionCommand : IRequest<long>
{
    public CreateEmployeeFinancialTransactionDto Dto { get; set; } = new();
}

public class UpdateEmployeeFinancialTransactionCommand : IRequest<bool>
{
    public UpdateEmployeeFinancialTransactionDto Dto { get; set; } = new();
}

public class DeleteEmployeeFinancialTransactionCommand : IRequest<bool>
{
    public long Id { get; set; }
}