using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrollFinancialContracts;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeePayrollFinancialContracts;

public class GetEmployeePayrollFinancialContractByIdQuery : IRequest<EmployeePayrollFinancialContractDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeePayrollFinancialContractsQuery : IRequest<IEnumerable<EmployeePayrollFinancialContractDto>>
{
}