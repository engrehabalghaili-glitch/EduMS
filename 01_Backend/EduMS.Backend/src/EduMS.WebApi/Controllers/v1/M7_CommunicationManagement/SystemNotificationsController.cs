using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.Controllers.v1.M7_CommunicationManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SystemNotificationsController(MediatR.ISender sender) : ControllerBase
{
    // API Endpoints for System Notification will be wired to MediatR here.
}

