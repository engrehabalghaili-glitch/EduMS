using EduMS.Application.M2_StudentAffairs.DTOs.BehavioralLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.BehavioralLogs;

public class CreateBehavioralLogCommand : IRequest<long>
{
    public CreateBehavioralLogDto Dto { get; set; } = new();
}

public class UpdateBehavioralLogCommand : IRequest<bool>
{
    public UpdateBehavioralLogDto Dto { get; set; } = new();
}

public class DeleteBehavioralLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}