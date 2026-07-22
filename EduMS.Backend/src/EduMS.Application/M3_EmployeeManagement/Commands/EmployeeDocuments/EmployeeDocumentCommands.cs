using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeDocuments;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeDocuments;

public class CreateEmployeeDocumentCommand : IRequest<long>
{
    public CreateEmployeeDocumentDto Dto { get; set; } = new();
}

public class UpdateEmployeeDocumentCommand : IRequest<bool>
{
    public UpdateEmployeeDocumentDto Dto { get; set; } = new();
}

public class DeleteEmployeeDocumentCommand : IRequest<bool>
{
    public long Id { get; set; }
}