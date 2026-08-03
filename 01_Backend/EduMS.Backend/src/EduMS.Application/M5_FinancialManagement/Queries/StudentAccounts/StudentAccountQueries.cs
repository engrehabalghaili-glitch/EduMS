using EduMS.Application.M5_FinancialManagement.DTOs.StudentAccounts;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.StudentAccounts;

public class GetStudentAccountByIdQuery : IRequest<StudentAccountDto>
{
    public long Id { get; set; }
}

public class GetAllStudentAccountsQuery : IRequest<IEnumerable<StudentAccountDto>>
{
}