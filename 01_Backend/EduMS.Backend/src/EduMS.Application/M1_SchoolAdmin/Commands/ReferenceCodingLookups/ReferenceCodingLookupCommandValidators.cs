using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ReferenceCodingLookups;

public class CreateReferenceCodingLookupCommandValidator : AbstractValidator<CreateReferenceCodingLookupCommand>
{
    public CreateReferenceCodingLookupCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateReferenceCodingLookupCommandValidator : AbstractValidator<UpdateReferenceCodingLookupCommand>
{
    public UpdateReferenceCodingLookupCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteReferenceCodingLookupCommandValidator : AbstractValidator<DeleteReferenceCodingLookupCommand>
{
    public DeleteReferenceCodingLookupCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}