using EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.Classrooms;

public class GetClassroomByIdQuery : IRequest<ClassroomDto>
{
    public long Id { get; set; }
}

public class GetAllClassroomsQuery : IRequest<IEnumerable<ClassroomDto>>
{
}