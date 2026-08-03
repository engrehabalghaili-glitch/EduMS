using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolAwards;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolAwards;

public class SchoolAwardQueryHandlers : 
    IRequestHandler<GetSchoolAwardByIdQuery, SchoolAwardDto>,
    IRequestHandler<GetAllSchoolAwardsQuery, IEnumerable<SchoolAwardDto>>
{
    private readonly IGenericRepository<SchoolAward> _repository;
    private readonly IMapper _mapper;

    public SchoolAwardQueryHandlers(IGenericRepository<SchoolAward> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolAwardDto> Handle(GetSchoolAwardByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolAward not found.");
        return _mapper.Map<SchoolAwardDto>(entity);
    }

    public async Task<IEnumerable<SchoolAwardDto>> Handle(GetAllSchoolAwardsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolAwardDto>>(entities);
    }
}