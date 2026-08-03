using System.Collections.Generic;
using EduMS.Application.Common.CQRS;
using EduMS.Application.M1_SchoolAdmin.DTOs.Schools;

namespace EduMS.Application.M1_SchoolAdmin.Queries;

public record GetSchoolsQuery(bool OnlyActive = true) : IQuery<IEnumerable<SchoolDto>>;
