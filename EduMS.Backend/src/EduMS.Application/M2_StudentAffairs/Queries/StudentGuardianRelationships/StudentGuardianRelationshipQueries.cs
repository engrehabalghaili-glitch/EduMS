using EduMS.Application.M2_StudentAffairs.DTOs.StudentGuardianRelationships;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentGuardianRelationships;

public class GetStudentGuardianRelationshipByIdQuery : IRequest<StudentGuardianRelationshipDto>
{
    public long Id { get; set; }
}

public class GetAllStudentGuardianRelationshipsQuery : IRequest<IEnumerable<StudentGuardianRelationshipDto>>
{
}