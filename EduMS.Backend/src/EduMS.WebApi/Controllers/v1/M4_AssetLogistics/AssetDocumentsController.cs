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
public class AssetDocumentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetDocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AssetDocumentDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetDocumentsQuery());
        return Ok(ApiResponse<IEnumerable<AssetDocumentDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AssetDocumentDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAssetDocumentByIdQuery { Id = id });
        return Ok(ApiResponse<AssetDocumentDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAssetDocumentDto dto)
    {
        var id = await _mediator.Send(new CreateAssetDocumentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAssetDocumentDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAssetDocumentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAssetDocumentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}