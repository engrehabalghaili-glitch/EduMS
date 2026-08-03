using EduMS.Application.M5_FinancialManagement.DTOs.PayrollDetails;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.PayrollDetails;

public class GetPayrollDetailByIdQuery : IRequest<PayrollDetailDto>
{
    public long Id { get; set; }
}

public class GetAllPayrollDetailsQuery : IRequest<IEnumerable<PayrollDetailDto>>
{
}