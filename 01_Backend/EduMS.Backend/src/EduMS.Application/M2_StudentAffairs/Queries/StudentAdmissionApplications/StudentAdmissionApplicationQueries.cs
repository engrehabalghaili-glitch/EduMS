using EduMS.Application.M2_StudentAffairs.DTOs.StudentAdmissionApplications;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAdmissionApplications;

public class GetStudentAdmissionApplicationByIdQuery : IRequest<StudentAdmissionApplicationDto>
{
    public long Id { get; set; }
}

public class GetAllStudentAdmissionApplicationsQuery : IRequest<IEnumerable<StudentAdmissionApplicationDto>>
{
}