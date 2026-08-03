using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetExpenses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetExpenses;

public class AssetExpenseQueryHandlers : 
    IRequestHandler<GetAssetExpenseByIdQuery, AssetExpenseDto>,
    IRequestHandler<GetAllAssetExpensesQuery, IEnumerable<AssetExpenseDto>>
{
    private readonly IGenericRepository<AssetExpense> _repository;
    private readonly IMapper _mapper;

    public AssetExpenseQueryHandlers(IGenericRepository<AssetExpense> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetExpenseDto> Handle(GetAssetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetExpense not found.");
        return _mapper.Map<AssetExpenseDto>(entity);
    }

    public async Task<IEnumerable<AssetExpenseDto>> Handle(GetAllAssetExpensesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetExpenseDto>>(entities);
    }
}