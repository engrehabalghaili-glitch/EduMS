using EduMS.Application.M2_StudentAffairs.DTOs.StudentParentConferenceReservations;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentParentConferenceReservations;

public class CreateStudentParentConferenceReservationCommand : IRequest<long>
{
    public CreateStudentParentConferenceReservationDto Dto { get; set; } = new();
}

public class UpdateStudentParentConferenceReservationCommand : IRequest<bool>
{
    public UpdateStudentParentConferenceReservationDto Dto { get; set; } = new();
}

public class DeleteStudentParentConferenceReservationCommand : IRequest<bool>
{
    public long Id { get; set; }
}