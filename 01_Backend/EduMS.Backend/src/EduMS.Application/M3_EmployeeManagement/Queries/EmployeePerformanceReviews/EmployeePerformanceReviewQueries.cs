using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePerformanceReviews;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeePerformanceReviews;

public class GetEmployeePerformanceReviewByIdQuery : IRequest<EmployeePerformanceReviewDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeePerformanceReviewsQuery : IRequest<IEnumerable<EmployeePerformanceReviewDto>>
{
}