using EduMS.Application.M3_EmployeeManagement.DTOs.JobApplicants;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.JobApplicants;

public class GetJobApplicantByIdQuery : IRequest<JobApplicantDto>
{
    public long Id { get; set; }
}

public class GetAllJobApplicantsQuery : IRequest<IEnumerable<JobApplicantDto>>
{
}