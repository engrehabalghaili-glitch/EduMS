using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolCanteenItems;

public class CreateSchoolCanteenItemCommand : IRequest<long>
{
    public CreateSchoolCanteenItemDto Dto { get; set; } = new();
}

public class UpdateSchoolCanteenItemCommand : IRequest<bool>
{
    public UpdateSchoolCanteenItemDto Dto { get; set; } = new();
}

public class DeleteSchoolCanteenItemCommand : IRequest<bool>
{
    public long Id { get; set; }
}