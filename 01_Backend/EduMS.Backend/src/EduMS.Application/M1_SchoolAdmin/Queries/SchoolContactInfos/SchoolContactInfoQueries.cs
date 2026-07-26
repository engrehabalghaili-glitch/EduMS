using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolContactInfos;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolContactInfos;

public class GetSchoolContactInfoByIdQuery : IRequest<SchoolContactInfoDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolContactInfosQuery : IRequest<IEnumerable<SchoolContactInfoDto>>
{
}