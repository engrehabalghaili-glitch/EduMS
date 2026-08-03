using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M4_AssetLogistics.Commands.AssetDocuments;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetDocuments;
using EduMS.Application.M4_AssetLogistics.Queries.AssetDocuments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M4_AssetLogistics;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssetDocumentsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.AssetDocuments.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetDocumentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllAssetDocumentsQuery());
        return Ok(ApiResponse<IEnumerable<AssetDocumentDto>>.Success(result));
    }

    [HasPermission(Permissions.AssetDocuments.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetDocumentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetAssetDocumentByIdQuery { Id = id });
        return Ok(ApiResponse<AssetDocumentDto>.Success(result));
    }

    [HasPermission(Permissions.AssetDocuments.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetDocumentDto dto)
    {
        var id = await sender.Send(new CreateAssetDocumentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.AssetDocuments.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetDocumentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateAssetDocumentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.AssetDocuments.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteAssetDocumentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




