using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeFinancialTransactions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeFinancialTransactions;

public class EmployeeFinancialTransactionQueryHandlers : 
    IRequestHandler<GetEmployeeFinancialTransactionByIdQuery, EmployeeFinancialTransactionDto>,
    IRequestHandler<GetAllEmployeeFinancialTransactionsQuery, IEnumerable<EmployeeFinancialTransactionDto>>
{
    private readonly IGenericRepository<EmployeeFinancialTransaction> _repository;
    private readonly IMapper _mapper;

    public EmployeeFinancialTransactionQueryHandlers(IGenericRepository<EmployeeFinancialTransaction> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeFinancialTransactionDto> Handle(GetEmployeeFinancialTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeFinancialTransaction not found.");
        return _mapper.Map<EmployeeFinancialTransactionDto>(entity);
    }

    public async Task<IEnumerable<EmployeeFinancialTransactionDto>> Handle(GetAllEmployeeFinancialTransactionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeFinancialTransactionDto>>(entities);
    }
}