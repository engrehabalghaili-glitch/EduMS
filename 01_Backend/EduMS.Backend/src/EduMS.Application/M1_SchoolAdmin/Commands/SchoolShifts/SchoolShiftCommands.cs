using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolShifts;

public class CreateSchoolShiftCommand : IRequest<long>
{
    public CreateSchoolShiftDto Dto { get; set; } = new();
}

public class UpdateSchoolShiftCommand : IRequest<bool>
{
    public UpdateSchoolShiftDto Dto { get; set; } = new();
}

public class DeleteSchoolShiftCommand : IRequest<bool>
{
    public long Id { get; set; }
}