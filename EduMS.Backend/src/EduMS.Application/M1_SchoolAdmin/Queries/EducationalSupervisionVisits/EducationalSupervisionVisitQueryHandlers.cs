using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalSupervisionVisits;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.EducationalSupervisionVisits;

public class EducationalSupervisionVisitQueryHandlers : 
    IRequestHandler<GetEducationalSupervisionVisitByIdQuery, EducationalSupervisionVisitDto>,
    IRequestHandler<GetAllEducationalSupervisionVisitsQuery, IEnumerable<EducationalSupervisionVisitDto>>
{
    private readonly IGenericRepository<EducationalSupervisionVisit> _repository;
    private readonly IMapper _mapper;

    public EducationalSupervisionVisitQueryHandlers(IGenericRepository<EducationalSupervisionVisit> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EducationalSupervisionVisitDto> Handle(GetEducationalSupervisionVisitByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EducationalSupervisionVisit not found.");
        return _mapper.Map<EducationalSupervisionVisitDto>(entity);
    }

    public async Task<IEnumerable<EducationalSupervisionVisitDto>> Handle(GetAllEducationalSupervisionVisitsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EducationalSupervisionVisitDto>>(entities);
    }
}