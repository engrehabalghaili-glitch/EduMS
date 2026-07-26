using EduMS.Application.M5_FinancialManagement.DTOs.StudentInvoices;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.StudentInvoices;

public class CreateStudentInvoiceCommand : IRequest<long>
{
    public CreateStudentInvoiceDto Dto { get; set; } = new();
}

public class UpdateStudentInvoiceCommand : IRequest<bool>
{
    public UpdateStudentInvoiceDto Dto { get; set; } = new();
}

public class DeleteStudentInvoiceCommand : IRequest<bool>
{
    public long Id { get; set; }
}