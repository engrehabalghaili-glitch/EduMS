using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.CommunityPartnerships;

public class CreateCommunityPartnershipCommandValidator : AbstractValidator<CreateCommunityPartnershipCommand>
{
    public CreateCommunityPartnershipCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateCommunityPartnershipCommandValidator : AbstractValidator<UpdateCommunityPartnershipCommand>
{
    public UpdateCommunityPartnershipCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteCommunityPartnershipCommandValidator : AbstractValidator<DeleteCommunityPartnershipCommand>
{
    public DeleteCommunityPartnershipCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}