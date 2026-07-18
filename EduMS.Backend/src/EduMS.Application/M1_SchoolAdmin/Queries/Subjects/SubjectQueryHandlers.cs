using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.Subjects;

public class SubjectQueryHandlers : 
    IRequestHandler<GetSubjectByIdQuery, SubjectDto>,
    IRequestHandler<GetAllSubjectsQuery, IEnumerable<SubjectDto>>
{
    private readonly IGenericRepository<Subject> _repository;
    private readonly IMapper _mapper;

    public SubjectQueryHandlers(IGenericRepository<Subject> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SubjectDto> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Subject not found.");
        return _mapper.Map<SubjectDto>(entity);
    }

    public async Task<IEnumerable<SubjectDto>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SubjectDto>>(entities);
    }
}