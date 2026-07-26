using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolCanteenItems;

public class GetSchoolCanteenItemByIdQuery : IRequest<SchoolCanteenItemDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolCanteenItemsQuery : IRequest<IEnumerable<SchoolCanteenItemDto>>
{
}