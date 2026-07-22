using EduMS.Application.M2_StudentAffairs.DTOs.StudentAttachments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAttachments;

public class GetStudentAttachmentByIdQuery : IRequest<StudentAttachmentDto>
{
    public long Id { get; set; }
}

public class GetAllStudentAttachmentsQuery : IRequest<IEnumerable<StudentAttachmentDto>>
{
}