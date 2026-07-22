using EduMS.Application.M2_StudentAffairs.DTOs.StudentCanteenPurchaseLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentCanteenPurchaseLogs;

public class GetStudentCanteenPurchaseLogByIdQuery : IRequest<StudentCanteenPurchaseLogDto>
{
    public long Id { get; set; }
}

public class GetAllStudentCanteenPurchaseLogsQuery : IRequest<IEnumerable<StudentCanteenPurchaseLogDto>>
{
}