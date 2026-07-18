using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.EducationalStages;

public class UpdateEducationalStageCommand : IRequest<bool>
{
    public UpdateEducationalStageDto Dto { get; set; } = new();
}