using EduMS.Application.Common.Responses;
using EduMS.Application.M1_SchoolAdmin.Commands.ReferenceCodingLookups;
using EduMS.Application.M1_SchoolAdmin.DTOs.ReferenceCodingLookups;
using EduMS.Application.M1_SchoolAdmin.Queries.ReferenceCodingLookups;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M1_SchoolAdmin;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ReferenceCodingLookupsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ReferenceCodingLookupDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllReferenceCodingLookupsQuery());
        return Ok(ApiResponse<IEnumerable<ReferenceCodingLookupDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ReferenceCodingLookupDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetReferenceCodingLookupByIdQuery { Id = id });
        return Ok(ApiResponse<ReferenceCodingLookupDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateReferenceCodingLookupDto dto)
    {
        var id = await sender.Send(new CreateReferenceCodingLookupCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateReferenceCodingLookupDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateReferenceCodingLookupCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteReferenceCodingLookupCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



