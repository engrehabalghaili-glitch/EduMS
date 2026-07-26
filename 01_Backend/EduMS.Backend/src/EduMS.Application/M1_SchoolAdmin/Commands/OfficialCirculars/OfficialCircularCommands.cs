using EduMS.Application.M1_SchoolAdmin.DTOs.OfficialCirculars;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.OfficialCirculars;

public class CreateOfficialCircularCommand : IRequest<long>
{
    public CreateOfficialCircularDto Dto { get; set; } = new();
}

public class UpdateOfficialCircularCommand : IRequest<bool>
{
    public UpdateOfficialCircularDto Dto { get; set; } = new();
}

public class DeleteOfficialCircularCommand : IRequest<bool>
{
    public long Id { get; set; }
}