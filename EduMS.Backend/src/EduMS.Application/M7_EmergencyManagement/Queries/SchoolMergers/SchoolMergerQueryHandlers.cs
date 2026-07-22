using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolMergers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolMergers;

public class SchoolMergerQueryHandlers : 
    IRequestHandler<GetSchoolMergerByIdQuery, SchoolMergerDto>,
    IRequestHandler<GetAllSchoolMergersQuery, IEnumerable<SchoolMergerDto>>
{
    private readonly IGenericRepository<SchoolMerger> _repository;
    private readonly IMapper _mapper;

    public SchoolMergerQueryHandlers(IGenericRepository<SchoolMerger> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolMergerDto> Handle(GetSchoolMergerByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolMerger not found.");
        return _mapper.Map<SchoolMergerDto>(entity);
    }

    public async Task<IEnumerable<SchoolMergerDto>> Handle(GetAllSchoolMergersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolMergerDto>>(entities);
    }
}