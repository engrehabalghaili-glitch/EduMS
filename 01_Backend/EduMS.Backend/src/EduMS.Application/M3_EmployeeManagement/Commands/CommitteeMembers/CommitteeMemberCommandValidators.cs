using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.CommitteeMembers;

public class CreateCommitteeMemberCommandValidator : AbstractValidator<CreateCommitteeMemberCommand>
{
    public CreateCommitteeMemberCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateCommitteeMemberCommandValidator : AbstractValidator<UpdateCommitteeMemberCommand>
{
    public UpdateCommitteeMemberCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteCommitteeMemberCommandValidator : AbstractValidator<DeleteCommitteeMemberCommand>
{
    public DeleteCommitteeMemberCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}