using EduMS.Application.M2_StudentAffairs.DTOs.StudentIdentityDocuments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentIdentityDocuments;

public class GetStudentIdentityDocumentByIdQuery : IRequest<StudentIdentityDocumentDto>
{
    public long Id { get; set; }
}

public class GetAllStudentIdentityDocumentsQuery : IRequest<IEnumerable<StudentIdentityDocumentDto>>
{
}