using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateLegalCaseLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateLegalCaseLogs;

public class CreateDirectorateLegalCaseLogCommand : IRequest<long>
{
    public CreateDirectorateLegalCaseLogDto Dto { get; set; } = new();
}

public class UpdateDirectorateLegalCaseLogCommand : IRequest<bool>
{
    public UpdateDirectorateLegalCaseLogDto Dto { get; set; } = new();
}

public class DeleteDirectorateLegalCaseLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}