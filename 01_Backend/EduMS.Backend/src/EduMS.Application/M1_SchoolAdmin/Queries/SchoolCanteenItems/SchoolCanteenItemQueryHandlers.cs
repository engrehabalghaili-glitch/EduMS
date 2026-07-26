using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolCanteenItems;

public class SchoolCanteenItemQueryHandlers : 
    IRequestHandler<GetSchoolCanteenItemByIdQuery, SchoolCanteenItemDto>,
    IRequestHandler<GetAllSchoolCanteenItemsQuery, IEnumerable<SchoolCanteenItemDto>>
{
    private readonly IGenericRepository<SchoolCanteenItem> _repository;
    private readonly IMapper _mapper;

    public SchoolCanteenItemQueryHandlers(IGenericRepository<SchoolCanteenItem> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolCanteenItemDto> Handle(GetSchoolCanteenItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolCanteenItem not found.");
        return _mapper.Map<SchoolCanteenItemDto>(entity);
    }

    public async Task<IEnumerable<SchoolCanteenItemDto>> Handle(GetAllSchoolCanteenItemsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolCanteenItemDto>>(entities);
    }
}