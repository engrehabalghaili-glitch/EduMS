using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetLoans;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoans;
using EduMS.Application.M4_AssetLogistics.Queries.AssetLoans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetLoansController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetLoans.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetLoanDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetLoansQuery());
        return Ok(ApiResponse<IEnumerable<AssetLoanDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetLoans.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetLoanDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetLoanByIdQuery { Id = id });
        return Ok(ApiResponse<AssetLoanDto>.Success(result));
    }

    [HasPermission(Permissions.AssetLoans.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetLoanDto dto)
    {
        var id = await sender.Send(new CreateAssetLoanCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetLoans.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetLoanDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetLoanCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetLoans.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetLoanCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




