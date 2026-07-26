using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialses;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialses;
using EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetFinancialsesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetFinancialsDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetFinancialsesQuery());
        return Ok(ApiResponse<IEnumerable<AssetFinancialsDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetFinancialsDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetFinancialsByIdQuery { Id = id });
        return Ok(ApiResponse<AssetFinancialsDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetFinancialsDto dto)
    {
        var id = await sender.Send(new CreateAssetFinancialsCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetFinancialsDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetFinancialsCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetFinancialsCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



