using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAnnouncementLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAnnouncementLogs;

public class CreateSchoolAnnouncementLogCommand : IRequest<long>
{
    public CreateSchoolAnnouncementLogDto Dto { get; set; } = new();
}

public class UpdateSchoolAnnouncementLogCommand : IRequest<bool>
{
    public UpdateSchoolAnnouncementLogDto Dto { get; set; } = new();
}

public class DeleteSchoolAnnouncementLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}