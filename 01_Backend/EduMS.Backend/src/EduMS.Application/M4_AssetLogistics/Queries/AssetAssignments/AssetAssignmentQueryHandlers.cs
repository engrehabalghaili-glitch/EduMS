using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetAssignments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetAssignments;

public class AssetAssignmentQueryHandlers : 
    IRequestHandler<GetAssetAssignmentByIdQuery, AssetAssignmentDto>,
    IRequestHandler<GetAllAssetAssignmentsQuery, IEnumerable<AssetAssignmentDto>>
{
    private readonly IGenericRepository<AssetAssignment> _repository;
    private readonly IMapper _mapper;

    public AssetAssignmentQueryHandlers(IGenericRepository<AssetAssignment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetAssignmentDto> Handle(GetAssetAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetAssignment not found.");
        return _mapper.Map<AssetAssignmentDto>(entity);
    }

    public async Task<IEnumerable<AssetAssignmentDto>> Handle(GetAllAssetAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetAssignmentDto>>(entities);
    }
}