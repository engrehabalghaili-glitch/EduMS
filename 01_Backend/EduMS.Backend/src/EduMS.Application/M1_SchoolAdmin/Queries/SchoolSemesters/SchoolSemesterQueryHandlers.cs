using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolSemesters;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolSemesters;

public class SchoolSemesterQueryHandlers : 
    IRequestHandler<GetSchoolSemesterByIdQuery, SchoolSemesterDto>,
    IRequestHandler<GetAllSchoolSemestersQuery, IEnumerable<SchoolSemesterDto>>
{
    private readonly IGenericRepository<SchoolSemester> _repository;
    private readonly IMapper _mapper;

    public SchoolSemesterQueryHandlers(IGenericRepository<SchoolSemester> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolSemesterDto> Handle(GetSchoolSemesterByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolSemester not found.");
        return _mapper.Map<SchoolSemesterDto>(entity);
    }

    public async Task<IEnumerable<SchoolSemesterDto>> Handle(GetAllSchoolSemestersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolSemesterDto>>(entities);
    }
}