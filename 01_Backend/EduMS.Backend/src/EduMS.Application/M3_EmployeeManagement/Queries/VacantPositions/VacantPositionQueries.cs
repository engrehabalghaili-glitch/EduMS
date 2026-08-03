using EduMS.Application.M3_EmployeeManagement.DTOs.VacantPositions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.VacantPositions;

public class GetVacantPositionByIdQuery : IRequest<VacantPositionDto>
{
    public long Id { get; set; }
}

public class GetAllVacantPositionsQuery : IRequest<IEnumerable<VacantPositionDto>>
{
}