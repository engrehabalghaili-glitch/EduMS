using EduMS.Application.M1_SchoolAdmin.DTOs.OfficialCirculars;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.OfficialCirculars;

public class GetOfficialCircularByIdQuery : IRequest<OfficialCircularDto>
{
    public long Id { get; set; }
}

public class GetAllOfficialCircularsQuery : IRequest<IEnumerable<OfficialCircularDto>>
{
}