using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Students.Queries;

public record GetStudentEnrollmentSummaryQuery(string EnrollmentNumber) : IQuery<StudentEnrollmentSummaryDto?>;
