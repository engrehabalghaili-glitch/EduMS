using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.Accounts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.Accounts;

public class AccountQueryHandlers : 
    IRequestHandler<GetAccountByIdQuery, AccountDto>,
    IRequestHandler<GetAllAccountsQuery, IEnumerable<AccountDto>>
{
    private readonly IGenericRepository<Account> _repository;
    private readonly IMapper _mapper;

    public AccountQueryHandlers(IGenericRepository<Account> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Account not found.");
        return _mapper.Map<AccountDto>(entity);
    }

    public async Task<IEnumerable<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AccountDto>>(entities);
    }
}