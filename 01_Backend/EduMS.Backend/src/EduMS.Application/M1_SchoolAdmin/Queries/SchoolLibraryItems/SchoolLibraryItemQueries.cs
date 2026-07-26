using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLibraryItems;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolLibraryItems;

public class GetSchoolLibraryItemByIdQuery : IRequest<SchoolLibraryItemDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolLibraryItemsQuery : IRequest<IEnumerable<SchoolLibraryItemDto>>
{
}