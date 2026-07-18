using EduMS.Application.M1_SchoolAdmin.DTOs.TrainingCourseOfferings;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.TrainingCourseOfferings;

public class CreateTrainingCourseOfferingCommand : IRequest<long>
{
    public CreateTrainingCourseOfferingDto Dto { get; set; } = new();
}

public class UpdateTrainingCourseOfferingCommand : IRequest<bool>
{
    public UpdateTrainingCourseOfferingDto Dto { get; set; } = new();
}

public class DeleteTrainingCourseOfferingCommand : IRequest<bool>
{
    public long Id { get; set; }
}