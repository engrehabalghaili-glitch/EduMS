using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassroomResourceAllocations;

public class CreateClassroomResourceAllocationCommandValidator : AbstractValidator<CreateClassroomResourceAllocationCommand>
{
    public CreateClassroomResourceAllocationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateClassroomResourceAllocationCommandValidator : AbstractValidator<UpdateClassroomResourceAllocationCommand>
{
    public UpdateClassroomResourceAllocationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteClassroomResourceAllocationCommandValidator : AbstractValidator<DeleteClassroomResourceAllocationCommand>
{
    public DeleteClassroomResourceAllocationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}