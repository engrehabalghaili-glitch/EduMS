using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePerformanceReviews;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeePerformanceReviews;

public class CreateEmployeePerformanceReviewCommand : IRequest<long>
{
    public CreateEmployeePerformanceReviewDto Dto { get; set; } = new();
}

public class UpdateEmployeePerformanceReviewCommand : IRequest<bool>
{
    public UpdateEmployeePerformanceReviewDto Dto { get; set; } = new();
}

public class DeleteEmployeePerformanceReviewCommand : IRequest<bool>
{
    public long Id { get; set; }
}