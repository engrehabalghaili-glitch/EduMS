using EduMS.Application.M2_StudentAffairs.DTOs.StudentCanteenPurchaseLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentCanteenPurchaseLogs;

public class CreateStudentCanteenPurchaseLogCommand : IRequest<long>
{
    public CreateStudentCanteenPurchaseLogDto Dto { get; set; } = new();
}

public class UpdateStudentCanteenPurchaseLogCommand : IRequest<bool>
{
    public UpdateStudentCanteenPurchaseLogDto Dto { get; set; } = new();
}

public class DeleteStudentCanteenPurchaseLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}