using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.EducationalStages;

public class DeleteEducationalStageCommand : IRequest<bool>
{
    public long Id { get; set; }
}