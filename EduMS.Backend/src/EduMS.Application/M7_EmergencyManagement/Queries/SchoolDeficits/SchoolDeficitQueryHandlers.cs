using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolDeficits;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolDeficits;

public class SchoolDeficitQueryHandlers : 
    IRequestHandler<GetSchoolDeficitByIdQuery, SchoolDeficitDto>,
    IRequestHandler<GetAllSchoolDeficitsQuery, IEnumerable<SchoolDeficitDto>>
{
    private readonly IGenericRepository<SchoolDeficit> _repository;
    private readonly IMapper _mapper;

    public SchoolDeficitQueryHandlers(IGenericRepository<SchoolDeficit> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolDeficitDto> Handle(GetSchoolDeficitByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolDeficit not found.");
        return _mapper.Map<SchoolDeficitDto>(entity);
    }

    public async Task<IEnumerable<SchoolDeficitDto>> Handle(GetAllSchoolDeficitsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolDeficitDto>>(entities);
    }
}