using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.TrainingCourseOfferings;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.TrainingCourseOfferings;

public class TrainingCourseOfferingQueryHandlers : 
    IRequestHandler<GetTrainingCourseOfferingByIdQuery, TrainingCourseOfferingDto>,
    IRequestHandler<GetAllTrainingCourseOfferingsQuery, IEnumerable<TrainingCourseOfferingDto>>
{
    private readonly IGenericRepository<TrainingCourseOffering> _repository;
    private readonly IMapper _mapper;

    public TrainingCourseOfferingQueryHandlers(IGenericRepository<TrainingCourseOffering> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TrainingCourseOfferingDto> Handle(GetTrainingCourseOfferingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"TrainingCourseOffering not found.");
        return _mapper.Map<TrainingCourseOfferingDto>(entity);
    }

    public async Task<IEnumerable<TrainingCourseOfferingDto>> Handle(GetAllTrainingCourseOfferingsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<TrainingCourseOfferingDto>>(entities);
    }
}