using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetDocuments;

public class CreateAssetDocumentCommandValidator : AbstractValidator<CreateAssetDocumentCommand>
{
    public CreateAssetDocumentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetDocumentCommandValidator : AbstractValidator<UpdateAssetDocumentCommand>
{
    public UpdateAssetDocumentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetDocumentCommandValidator : AbstractValidator<DeleteAssetDocumentCommand>
{
    public DeleteAssetDocumentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}