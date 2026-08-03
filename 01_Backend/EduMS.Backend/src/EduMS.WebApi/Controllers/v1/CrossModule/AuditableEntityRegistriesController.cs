using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.Controllers.v1.CrossModule;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AuditableEntityRegistriesController(MediatR.ISender sender) : ControllerBase
{
    // API Endpoints for Auditable Entity Registry will be wired to MediatR here.
}
