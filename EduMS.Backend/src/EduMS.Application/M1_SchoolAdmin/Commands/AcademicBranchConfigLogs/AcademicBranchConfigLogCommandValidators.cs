using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicBranchConfigLogs;

public class CreateAcademicBranchConfigLogCommandValidator : AbstractValidator<CreateAcademicBranchConfigLogCommand>
{
    public CreateAcademicBranchConfigLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAcademicBranchConfigLogCommandValidator : AbstractValidator<UpdateAcademicBranchConfigLogCommand>
{
    public UpdateAcademicBranchConfigLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAcademicBranchConfigLogCommandValidator : AbstractValidator<DeleteAcademicBranchConfigLogCommand>
{
    public DeleteAcademicBranchConfigLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}