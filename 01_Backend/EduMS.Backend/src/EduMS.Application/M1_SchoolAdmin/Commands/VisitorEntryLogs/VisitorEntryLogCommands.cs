using EduMS.Application.M1_SchoolAdmin.DTOs.VisitorEntryLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.VisitorEntryLogs;

public class CreateVisitorEntryLogCommand : IRequest<long>
{
    public CreateVisitorEntryLogDto Dto { get; set; } = new();
}

public class UpdateVisitorEntryLogCommand : IRequest<bool>
{
    public UpdateVisitorEntryLogDto Dto { get; set; } = new();
}

public class DeleteVisitorEntryLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}