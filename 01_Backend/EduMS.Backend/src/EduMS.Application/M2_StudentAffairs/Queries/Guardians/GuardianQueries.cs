using EduMS.Application.M2_StudentAffairs.DTOs.Guardians;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.Guardians;

public class GetGuardianByIdQuery : IRequest<GuardianDto>
{
    public long Id { get; set; }
}

public class GetAllGuardiansQuery : IRequest<IEnumerable<GuardianDto>>
{
}