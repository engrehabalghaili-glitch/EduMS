using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetWarrantyContracts;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetWarrantyContracts;
using EduMS.Application.M4_AssetLogistics.Queries.AssetWarrantyContracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetWarrantyContractsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetWarrantyContractDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetWarrantyContractsQuery());
        return Ok(ApiResponse<IEnumerable<AssetWarrantyContractDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetWarrantyContractDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetWarrantyContractByIdQuery { Id = id });
        return Ok(ApiResponse<AssetWarrantyContractDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetWarrantyContractDto dto)
    {
        var id = await sender.Send(new CreateAssetWarrantyContractCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetWarrantyContractDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetWarrantyContractCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetWarrantyContractCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



