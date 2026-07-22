using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.ReferenceCodingLookups;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ReferenceCodingLookups;

public class ReferenceCodingLookupQueryHandlers : 
    IRequestHandler<GetReferenceCodingLookupByIdQuery, ReferenceCodingLookupDto>,
    IRequestHandler<GetAllReferenceCodingLookupsQuery, IEnumerable<ReferenceCodingLookupDto>>
{
    private readonly IGenericRepository<ReferenceCodingLookup> _repository;
    private readonly IMapper _mapper;

    public ReferenceCodingLookupQueryHandlers(IGenericRepository<ReferenceCodingLookup> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReferenceCodingLookupDto> Handle(GetReferenceCodingLookupByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ReferenceCodingLookup not found.");
        return _mapper.Map<ReferenceCodingLookupDto>(entity);
    }

    public async Task<IEnumerable<ReferenceCodingLookupDto>> Handle(GetAllReferenceCodingLookupsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ReferenceCodingLookupDto>>(entities);
    }
}