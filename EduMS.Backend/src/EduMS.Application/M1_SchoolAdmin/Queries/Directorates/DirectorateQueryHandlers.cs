using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.Directorates;

public class DirectorateQueryHandlers : 
    IRequestHandler<GetDirectorateByIdQuery, DirectorateDto>,
    IRequestHandler<GetAllDirectoratesQuery, IEnumerable<DirectorateDto>>
{
    private readonly IGenericRepository<Directorate> _repository;
    private readonly IMapper _mapper;

    public DirectorateQueryHandlers(IGenericRepository<Directorate> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DirectorateDto> Handle(GetDirectorateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Directorate not found.");
        return _mapper.Map<DirectorateDto>(entity);
    }

    public async Task<IEnumerable<DirectorateDto>> Handle(GetAllDirectoratesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DirectorateDto>>(entities);
    }
}