using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.EducationalStages;

public class CreateEducationalStageCommand : IRequest<long>
{
    public CreateEducationalStageDto Dto { get; set; } = new();
}