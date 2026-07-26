using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeFinancialTransactions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeFinancialTransactions;

public class GetEmployeeFinancialTransactionByIdQuery : IRequest<EmployeeFinancialTransactionDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeFinancialTransactionsQuery : IRequest<IEnumerable<EmployeeFinancialTransactionDto>>
{
}