using EduMS.Application.M2_StudentAffairs.DTOs.StudentInventoryCustodies;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentInventoryCustodies;

public class GetStudentInventoryCustodyByIdQuery : IRequest<StudentInventoryCustodyDto>
{
    public long Id { get; set; }
}

public class GetAllStudentInventoryCustodiesQuery : IRequest<IEnumerable<StudentInventoryCustodyDto>>
{
}