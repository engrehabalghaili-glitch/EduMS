using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolContactInfos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolContactInfos;

public class SchoolContactInfoQueryHandlers : 
    IRequestHandler<GetSchoolContactInfoByIdQuery, SchoolContactInfoDto>,
    IRequestHandler<GetAllSchoolContactInfosQuery, IEnumerable<SchoolContactInfoDto>>
{
    private readonly IGenericRepository<SchoolContactInfo> _repository;
    private readonly IMapper _mapper;

    public SchoolContactInfoQueryHandlers(IGenericRepository<SchoolContactInfo> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolContactInfoDto> Handle(GetSchoolContactInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolContactInfo not found.");
        return _mapper.Map<SchoolContactInfoDto>(entity);
    }

    public async Task<IEnumerable<SchoolContactInfoDto>> Handle(GetAllSchoolContactInfosQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolContactInfoDto>>(entities);
    }
}