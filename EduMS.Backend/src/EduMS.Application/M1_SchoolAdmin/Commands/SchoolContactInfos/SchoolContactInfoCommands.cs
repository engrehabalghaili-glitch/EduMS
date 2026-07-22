using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolContactInfos;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolContactInfos;

public class CreateSchoolContactInfoCommand : IRequest<long>
{
    public CreateSchoolContactInfoDto Dto { get; set; } = new();
}

public class UpdateSchoolContactInfoCommand : IRequest<bool>
{
    public UpdateSchoolContactInfoDto Dto { get; set; } = new();
}

public class DeleteSchoolContactInfoCommand : IRequest<bool>
{
    public long Id { get; set; }
}