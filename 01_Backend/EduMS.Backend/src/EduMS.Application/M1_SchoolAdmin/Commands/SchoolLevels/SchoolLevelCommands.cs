using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLevels;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolLevels;

public class CreateSchoolLevelCommand : IRequest<long>
{
    public CreateSchoolLevelDto Dto { get; set; } = new();
}

public class UpdateSchoolLevelCommand : IRequest<bool>
{
    public UpdateSchoolLevelDto Dto { get; set; } = new();
}

public class DeleteSchoolLevelCommand : IRequest<bool>
{
    public long Id { get; set; }
}