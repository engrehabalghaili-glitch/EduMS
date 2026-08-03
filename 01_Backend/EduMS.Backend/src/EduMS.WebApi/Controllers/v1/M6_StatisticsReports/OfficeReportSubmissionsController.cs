using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.Controllers.v1.M6_StatisticsReports;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class OfficeReportSubmissionsController(MediatR.ISender sender) : ControllerBase
{
    // API Endpoints for Office Report Submission will be wired to MediatR here.
}

