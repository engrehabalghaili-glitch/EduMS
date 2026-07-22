using EduMS.Application.M2_StudentAffairs.DTOs.Persons;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.Persons;

public class CreatePersonCommand : IRequest<long>
{
    public CreatePersonDto Dto { get; set; } = new();
}

public class UpdatePersonCommand : IRequest<bool>
{
    public UpdatePersonDto Dto { get; set; } = new();
}

public class DeletePersonCommand : IRequest<bool>
{
    public long Id { get; set; }
}