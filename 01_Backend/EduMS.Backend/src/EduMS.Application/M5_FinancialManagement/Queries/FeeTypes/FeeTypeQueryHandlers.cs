using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeTypes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeTypes;

public class FeeTypeQueryHandlers : 
    IRequestHandler<GetFeeTypeByIdQuery, FeeTypeDto>,
    IRequestHandler<GetAllFeeTypesQuery, IEnumerable<FeeTypeDto>>
{
    private readonly IGenericRepository<FeeType> _repository;
    private readonly IMapper _mapper;

    public FeeTypeQueryHandlers(IGenericRepository<FeeType> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FeeTypeDto> Handle(GetFeeTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FeeType not found.");
        return _mapper.Map<FeeTypeDto>(entity);
    }

    public async Task<IEnumerable<FeeTypeDto>> Handle(GetAllFeeTypesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FeeTypeDto>>(entities);
    }
}