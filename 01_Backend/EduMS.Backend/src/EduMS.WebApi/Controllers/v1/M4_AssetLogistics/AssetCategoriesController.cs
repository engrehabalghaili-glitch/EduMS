using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetCategories;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetCategories;
using EduMS.Application.M4_AssetLogistics.Queries.AssetCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetCategoriesController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetCategories.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetCategoryDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetCategoriesQuery());
        return Ok(ApiResponse<IEnumerable<AssetCategoryDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetCategories.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetCategoryDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetCategoryByIdQuery { Id = id });
        return Ok(ApiResponse<AssetCategoryDto>.Success(result));
    }

    [HasPermission(Permissions.AssetCategories.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetCategoryDto dto)
    {
        var id = await sender.Send(new CreateAssetCategoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetCategories.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetCategoryDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetCategoryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetCategories.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetCategoryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




