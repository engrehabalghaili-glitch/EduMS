using EduMS.Application.Common.Responses;
using EduMS.Application.M5_FinancialManagement.Commands.Accounts;
using EduMS.Application.M5_FinancialManagement.DTOs.Accounts;
using EduMS.Application.M5_FinancialManagement.Queries.Accounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M5_FinancialManagement;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AccountDto>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllAccountsQuery());
        return Ok(ApiResponse<IEnumerable<AccountDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AccountDto>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetAccountByIdQuery { Id = id });
        return Ok(ApiResponse<AccountDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateAccountDto dto)
    {
        var id = await _mediator.Send(new CreateAccountCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateAccountDto dto)
    {
        dto.Id = id;
        var result = await _mediator.Send(new UpdateAccountCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteAccountCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}