using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLibraryItems;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolLibraryItems;

public class SchoolLibraryItemQueryHandlers : 
    IRequestHandler<GetSchoolLibraryItemByIdQuery, SchoolLibraryItemDto>,
    IRequestHandler<GetAllSchoolLibraryItemsQuery, IEnumerable<SchoolLibraryItemDto>>
{
    private readonly IGenericRepository<SchoolLibraryItem> _repository;
    private readonly IMapper _mapper;

    public SchoolLibraryItemQueryHandlers(IGenericRepository<SchoolLibraryItem> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolLibraryItemDto> Handle(GetSchoolLibraryItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolLibraryItem not found.");
        return _mapper.Map<SchoolLibraryItemDto>(entity);
    }

    public async Task<IEnumerable<SchoolLibraryItemDto>> Handle(GetAllSchoolLibraryItemsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolLibraryItemDto>>(entities);
    }
}