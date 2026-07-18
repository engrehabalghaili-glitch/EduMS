using EduMS.Application.M3_EmployeeManagement.DTOs.JobApplicants;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.JobApplicants;

public class CreateJobApplicantCommand : IRequest<long>
{
    public CreateJobApplicantDto Dto { get; set; } = new();
}

public class UpdateJobApplicantCommand : IRequest<bool>
{
    public UpdateJobApplicantDto Dto { get; set; } = new();
}

public class DeleteJobApplicantCommand : IRequest<bool>
{
    public long Id { get; set; }
}