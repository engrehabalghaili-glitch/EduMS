using System;
using EduMS.Application.Common.CQRS;
using EduMS.Application.M1_SchoolAdmin.DTOs.Schools;

namespace EduMS.Application.M1_SchoolAdmin.Commands;

public record CreateSchoolCommand(CreateSchoolDto SchoolDto) : ICommand<long>;
