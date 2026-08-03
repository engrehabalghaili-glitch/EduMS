using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetTechnicalSpecifications;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetTechnicalSpecifications;
using EduMS.Application.M4_AssetLogistics.Queries.AssetTechnicalSpecifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetTechnicalSpecificationsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetTechnicalSpecifications.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetTechnicalSpecificationDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetTechnicalSpecificationsQuery());
        return Ok(ApiResponse<IEnumerable<AssetTechnicalSpecificationDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetTechnicalSpecifications.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetTechnicalSpecificationDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetTechnicalSpecificationByIdQuery { Id = id });
        return Ok(ApiResponse<AssetTechnicalSpecificationDto>.Success(result));
    }

    [HasPermission(Permissions.AssetTechnicalSpecifications.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetTechnicalSpecificationDto dto)
    {
        var id = await sender.Send(new CreateAssetTechnicalSpecificationCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetTechnicalSpecifications.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetTechnicalSpecificationDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetTechnicalSpecificationCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetTechnicalSpecifications.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetTechnicalSpecificationCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




