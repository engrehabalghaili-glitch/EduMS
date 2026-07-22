using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicLockPeriods;

public class CreateAcademicLockPeriodCommand : IRequest<long>
{
    public CreateAcademicLockPeriodDto Dto { get; set; } = new();
}

public class UpdateAcademicLockPeriodCommand : IRequest<bool>
{
    public UpdateAcademicLockPeriodDto Dto { get; set; } = new();
}

public class DeleteAcademicLockPeriodCommand : IRequest<bool>
{
    public long Id { get; set; }
}