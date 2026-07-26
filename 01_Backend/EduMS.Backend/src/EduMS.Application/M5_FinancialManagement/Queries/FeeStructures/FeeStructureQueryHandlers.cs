using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeStructures;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeStructures;

public class FeeStructureQueryHandlers : 
    IRequestHandler<GetFeeStructureByIdQuery, FeeStructureDto>,
    IRequestHandler<GetAllFeeStructuresQuery, IEnumerable<FeeStructureDto>>
{
    private readonly IGenericRepository<FeeStructure> _repository;
    private readonly IMapper _mapper;

    public FeeStructureQueryHandlers(IGenericRepository<FeeStructure> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FeeStructureDto> Handle(GetFeeStructureByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FeeStructure not found.");
        return _mapper.Map<FeeStructureDto>(entity);
    }

    public async Task<IEnumerable<FeeStructureDto>> Handle(GetAllFeeStructuresQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FeeStructureDto>>(entities);
    }
}