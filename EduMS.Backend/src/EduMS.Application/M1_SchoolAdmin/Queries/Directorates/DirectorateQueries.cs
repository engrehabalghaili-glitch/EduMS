using EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.Directorates;

public class GetDirectorateByIdQuery : IRequest<DirectorateDto>
{
    public long Id { get; set; }
}

public class GetAllDirectoratesQuery : IRequest<IEnumerable<DirectorateDto>>
{
}