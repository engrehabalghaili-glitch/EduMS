using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.OfficialCirculars;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.OfficialCirculars;

public class OfficialCircularQueryHandlers : 
    IRequestHandler<GetOfficialCircularByIdQuery, OfficialCircularDto>,
    IRequestHandler<GetAllOfficialCircularsQuery, IEnumerable<OfficialCircularDto>>
{
    private readonly IGenericRepository<OfficialCircular> _repository;
    private readonly IMapper _mapper;

    public OfficialCircularQueryHandlers(IGenericRepository<OfficialCircular> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OfficialCircularDto> Handle(GetOfficialCircularByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"OfficialCircular not found.");
        return _mapper.Map<OfficialCircularDto>(entity);
    }

    public async Task<IEnumerable<OfficialCircularDto>> Handle(GetAllOfficialCircularsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<OfficialCircularDto>>(entities);
    }
}