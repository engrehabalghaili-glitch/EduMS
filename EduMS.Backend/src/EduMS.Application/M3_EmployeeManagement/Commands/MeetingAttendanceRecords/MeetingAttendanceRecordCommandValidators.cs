using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.MeetingAttendanceRecords;

public class CreateMeetingAttendanceRecordCommandValidator : AbstractValidator<CreateMeetingAttendanceRecordCommand>
{
    public CreateMeetingAttendanceRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateMeetingAttendanceRecordCommandValidator : AbstractValidator<UpdateMeetingAttendanceRecordCommand>
{
    public UpdateMeetingAttendanceRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteMeetingAttendanceRecordCommandValidator : AbstractValidator<DeleteMeetingAttendanceRecordCommand>
{
    public DeleteMeetingAttendanceRecordCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}