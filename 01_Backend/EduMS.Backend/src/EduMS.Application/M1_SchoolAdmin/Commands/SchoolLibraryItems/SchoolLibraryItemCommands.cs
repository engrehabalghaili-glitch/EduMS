using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLibraryItems;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolLibraryItems;

public class CreateSchoolLibraryItemCommand : IRequest<long>
{
    public CreateSchoolLibraryItemDto Dto { get; set; } = new();
}

public class UpdateSchoolLibraryItemCommand : IRequest<bool>
{
    public UpdateSchoolLibraryItemDto Dto { get; set; } = new();
}

public class DeleteSchoolLibraryItemCommand : IRequest<bool>
{
    public long Id { get; set; }
}