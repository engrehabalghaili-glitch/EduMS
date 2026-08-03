using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportPreferences;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentTransportPreferences;

public class CreateStudentTransportPreferenceCommand : IRequest<long>
{
    public CreateStudentTransportPreferenceDto Dto { get; set; } = new();
}

public class UpdateStudentTransportPreferenceCommand : IRequest<bool>
{
    public UpdateStudentTransportPreferenceDto Dto { get; set; } = new();
}

public class DeleteStudentTransportPreferenceCommand : IRequest<bool>
{
    public long Id { get; set; }
}