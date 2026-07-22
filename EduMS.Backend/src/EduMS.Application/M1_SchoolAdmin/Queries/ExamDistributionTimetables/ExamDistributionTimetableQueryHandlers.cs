using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.ExamDistributionTimetables;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ExamDistributionTimetables;

public class ExamDistributionTimetableQueryHandlers : 
    IRequestHandler<GetExamDistributionTimetableByIdQuery, ExamDistributionTimetableDto>,
    IRequestHandler<GetAllExamDistributionTimetablesQuery, IEnumerable<ExamDistributionTimetableDto>>
{
    private readonly IGenericRepository<ExamDistributionTimetable> _repository;
    private readonly IMapper _mapper;

    public ExamDistributionTimetableQueryHandlers(IGenericRepository<ExamDistributionTimetable> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ExamDistributionTimetableDto> Handle(GetExamDistributionTimetableByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ExamDistributionTimetable not found.");
        return _mapper.Map<ExamDistributionTimetableDto>(entity);
    }

    public async Task<IEnumerable<ExamDistributionTimetableDto>> Handle(GetAllExamDistributionTimetablesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ExamDistributionTimetableDto>>(entities);
    }
}