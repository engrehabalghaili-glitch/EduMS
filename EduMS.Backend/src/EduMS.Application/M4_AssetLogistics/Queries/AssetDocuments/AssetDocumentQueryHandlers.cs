using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetDocuments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetDocuments;

public class AssetDocumentQueryHandlers : 
    IRequestHandler<GetAssetDocumentByIdQuery, AssetDocumentDto>,
    IRequestHandler<GetAllAssetDocumentsQuery, IEnumerable<AssetDocumentDto>>
{
    private readonly IGenericRepository<AssetDocument> _repository;
    private readonly IMapper _mapper;

    public AssetDocumentQueryHandlers(IGenericRepository<AssetDocument> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetDocumentDto> Handle(GetAssetDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetDocument not found.");
        return _mapper.Map<AssetDocumentDto>(entity);
    }

    public async Task<IEnumerable<AssetDocumentDto>> Handle(GetAllAssetDocumentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetDocumentDto>>(entities);
    }
}