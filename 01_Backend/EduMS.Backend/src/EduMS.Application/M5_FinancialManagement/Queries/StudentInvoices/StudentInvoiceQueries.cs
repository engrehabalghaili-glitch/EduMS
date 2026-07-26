using EduMS.Application.M5_FinancialManagement.DTOs.StudentInvoices;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.StudentInvoices;

public class GetStudentInvoiceByIdQuery : IRequest<StudentInvoiceDto>
{
    public long Id { get; set; }
}

public class GetAllStudentInvoicesQuery : IRequest<IEnumerable<StudentInvoiceDto>>
{
}