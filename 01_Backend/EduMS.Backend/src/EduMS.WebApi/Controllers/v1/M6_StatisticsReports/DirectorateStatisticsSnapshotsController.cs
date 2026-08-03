using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class DirectorateStatisticsSnapshotsController(MediatR.ISender sender) : ControllerBase
{
    // API Endpoints for Directorate Statistics Snapshot will be wired to MediatR here.
}

