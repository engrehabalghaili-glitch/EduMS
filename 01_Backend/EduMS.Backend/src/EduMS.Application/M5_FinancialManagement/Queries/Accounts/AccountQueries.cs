using EduMS.Application.M5_FinancialManagement.DTOs.Accounts;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.Accounts;

public class GetAccountByIdQuery : IRequest<AccountDto>
{
    public long Id { get; set; }
}

public class GetAllAccountsQuery : IRequest<IEnumerable<AccountDto>>
{
}