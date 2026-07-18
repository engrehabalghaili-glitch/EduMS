using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAnnouncementLogs;

public class CreateSchoolAnnouncementLogCommandValidator : AbstractValidator<CreateSchoolAnnouncementLogCommand>
{
    public CreateSchoolAnnouncementLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolAnnouncementLogCommandValidator : AbstractValidator<UpdateSchoolAnnouncementLogCommand>
{
    public UpdateSchoolAnnouncementLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolAnnouncementLogCommandValidator : AbstractValidator<DeleteSchoolAnnouncementLogCommand>
{
    public DeleteSchoolAnnouncementLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}