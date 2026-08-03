using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeDocuments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeDocuments;

public class GetEmployeeDocumentByIdQuery : IRequest<EmployeeDocumentDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeDocumentsQuery : IRequest<IEnumerable<EmployeeDocumentDto>>
{
}