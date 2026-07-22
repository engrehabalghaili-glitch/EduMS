using EduMS.Application.M1_SchoolAdmin.DTOs.TrainingCourseOfferings;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.TrainingCourseOfferings;

public class GetTrainingCourseOfferingByIdQuery : IRequest<TrainingCourseOfferingDto>
{
    public long Id { get; set; }
}

public class GetAllTrainingCourseOfferingsQuery : IRequest<IEnumerable<TrainingCourseOfferingDto>>
{
}