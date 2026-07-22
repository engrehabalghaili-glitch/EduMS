using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTrainings;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeTrainings;

public class GetEmployeeTrainingByIdQuery : IRequest<EmployeeTrainingDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeTrainingsQuery : IRequest<IEnumerable<EmployeeTrainingDto>>
{
}