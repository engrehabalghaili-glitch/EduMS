using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.VacantPositions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.VacantPositions;

public class VacantPositionQueryHandlers : 
    IRequestHandler<GetVacantPositionByIdQuery, VacantPositionDto>,
    IRequestHandler<GetAllVacantPositionsQuery, IEnumerable<VacantPositionDto>>
{
    private readonly IGenericRepository<VacantPosition> _repository;
    private readonly IMapper _mapper;

    public VacantPositionQueryHandlers(IGenericRepository<VacantPosition> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VacantPositionDto> Handle(GetVacantPositionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"VacantPosition not found.");
        return _mapper.Map<VacantPositionDto>(entity);
    }

    public async Task<IEnumerable<VacantPositionDto>> Handle(GetAllVacantPositionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<VacantPositionDto>>(entities);
    }
}