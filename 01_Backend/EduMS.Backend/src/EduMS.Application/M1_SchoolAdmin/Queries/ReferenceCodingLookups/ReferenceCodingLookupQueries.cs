using EduMS.Application.M1_SchoolAdmin.DTOs.ReferenceCodingLookups;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ReferenceCodingLookups;

public class GetReferenceCodingLookupByIdQuery : IRequest<ReferenceCodingLookupDto>
{
    public long Id { get; set; }
}

public class GetAllReferenceCodingLookupsQuery : IRequest<IEnumerable<ReferenceCodingLookupDto>>
{
}