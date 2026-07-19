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
public class AssetCategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetCategoryDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetCategoriesQuery());
        return Ok(ApiResponse<IEnumerable<AssetCategoryDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetCategoryDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetCategoryByIdQuery { Id = id });
        return Ok(ApiResponse<AssetCategoryDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetCategoryDto dto)
    {
        var id = await _mediator.Send(new CreateAssetCategoryCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetCategoryDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetCategoryCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetCategoryCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}