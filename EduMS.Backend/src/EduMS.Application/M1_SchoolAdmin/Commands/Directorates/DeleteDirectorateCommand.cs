using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Directorates;

public class DeleteDirectorateCommand : IRequest<bool>
{
    public long Id { get; set; }
}