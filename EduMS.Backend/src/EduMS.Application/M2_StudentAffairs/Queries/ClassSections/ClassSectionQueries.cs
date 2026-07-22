using EduMS.Application.M2_StudentAffairs.DTOs.ClassSections;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.ClassSections;

public class GetClassSectionByIdQuery : IRequest<ClassSectionDto>
{
    public long Id { get; set; }
}

public class GetAllClassSectionsQuery : IRequest<IEnumerable<ClassSectionDto>>
{
}