using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.Guardians;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.Guardians;

public class GuardianQueryHandlers : 
    IRequestHandler<GetGuardianByIdQuery, GuardianDto>,
    IRequestHandler<GetAllGuardiansQuery, IEnumerable<GuardianDto>>
{
    private readonly IGenericRepository<Guardian> _repository;
    private readonly IMapper _mapper;

    public GuardianQueryHandlers(IGenericRepository<Guardian> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GuardianDto> Handle(GetGuardianByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Guardian not found.");
        return _mapper.Map<GuardianDto>(entity);
    }

    public async Task<IEnumerable<GuardianDto>> Handle(GetAllGuardiansQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<GuardianDto>>(entities);
    }
}