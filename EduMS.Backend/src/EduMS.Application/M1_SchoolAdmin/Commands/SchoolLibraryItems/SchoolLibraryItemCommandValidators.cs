using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolLibraryItems;

public class CreateSchoolLibraryItemCommandValidator : AbstractValidator<CreateSchoolLibraryItemCommand>
{
    public CreateSchoolLibraryItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolLibraryItemCommandValidator : AbstractValidator<UpdateSchoolLibraryItemCommand>
{
    public UpdateSchoolLibraryItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolLibraryItemCommandValidator : AbstractValidator<DeleteSchoolLibraryItemCommand>
{
    public DeleteSchoolLibraryItemCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}