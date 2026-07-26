using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentLibraryBorrowingLogs;

public class CreateStudentLibraryBorrowingLogCommandValidator : AbstractValidator<CreateStudentLibraryBorrowingLogCommand>
{
    public CreateStudentLibraryBorrowingLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentLibraryBorrowingLogCommandValidator : AbstractValidator<UpdateStudentLibraryBorrowingLogCommand>
{
    public UpdateStudentLibraryBorrowingLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentLibraryBorrowingLogCommandValidator : AbstractValidator<DeleteStudentLibraryBorrowingLogCommand>
{
    public DeleteStudentLibraryBorrowingLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}