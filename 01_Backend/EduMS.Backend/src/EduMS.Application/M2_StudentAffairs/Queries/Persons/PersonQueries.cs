using EduMS.Application.M2_StudentAffairs.DTOs.Persons;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.Persons;

public class GetPersonByIdQuery : IRequest<PersonDto>
{
    public long Id { get; set; }
}

public class GetAllPersonsQuery : IRequest<IEnumerable<PersonDto>>
{
}