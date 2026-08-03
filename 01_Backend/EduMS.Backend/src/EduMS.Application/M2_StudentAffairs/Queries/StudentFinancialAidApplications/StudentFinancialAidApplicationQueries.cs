using EduMS.Application.M2_StudentAffairs.DTOs.StudentFinancialAidApplications;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentFinancialAidApplications;

public class GetStudentFinancialAidApplicationByIdQuery : IRequest<StudentFinancialAidApplicationDto>
{
    public long Id { get; set; }
}

public class GetAllStudentFinancialAidApplicationsQuery : IRequest<IEnumerable<StudentFinancialAidApplicationDto>>
{
}