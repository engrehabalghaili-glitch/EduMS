using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.DepreciationTransactions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.DepreciationTransactions;

public class DepreciationTransactionQueryHandlers : 
    IRequestHandler<GetDepreciationTransactionByIdQuery, DepreciationTransactionDto>,
    IRequestHandler<GetAllDepreciationTransactionsQuery, IEnumerable<DepreciationTransactionDto>>
{
    private readonly IGenericRepository<DepreciationTransaction> _repository;
    private readonly IMapper _mapper;

    public DepreciationTransactionQueryHandlers(IGenericRepository<DepreciationTransaction> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DepreciationTransactionDto> Handle(GetDepreciationTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DepreciationTransaction not found.");
        return _mapper.Map<DepreciationTransactionDto>(entity);
    }

    public async Task<IEnumerable<DepreciationTransactionDto>> Handle(GetAllDepreciationTransactionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DepreciationTransactionDto>>(entities);
    }
}