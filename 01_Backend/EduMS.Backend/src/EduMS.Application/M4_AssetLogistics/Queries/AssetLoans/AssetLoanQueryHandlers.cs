using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoans;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetLoans;

public class AssetLoanQueryHandlers : 
    IRequestHandler<GetAssetLoanByIdQuery, AssetLoanDto>,
    IRequestHandler<GetAllAssetLoansQuery, IEnumerable<AssetLoanDto>>
{
    private readonly IGenericRepository<AssetLoan> _repository;
    private readonly IMapper _mapper;

    public AssetLoanQueryHandlers(IGenericRepository<AssetLoan> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetLoanDto> Handle(GetAssetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetLoan not found.");
        return _mapper.Map<AssetLoanDto>(entity);
    }

    public async Task<IEnumerable<AssetLoanDto>> Handle(GetAllAssetLoansQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetLoanDto>>(entities);
    }
}