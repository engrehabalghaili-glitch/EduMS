using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.VacantPositions;

public class CreateVacantPositionCommandValidator : AbstractValidator<CreateVacantPositionCommand>
{
    public CreateVacantPositionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateVacantPositionCommandValidator : AbstractValidator<UpdateVacantPositionCommand>
{
    public UpdateVacantPositionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteVacantPositionCommandValidator : AbstractValidator<DeleteVacantPositionCommand>
{
    public DeleteVacantPositionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}