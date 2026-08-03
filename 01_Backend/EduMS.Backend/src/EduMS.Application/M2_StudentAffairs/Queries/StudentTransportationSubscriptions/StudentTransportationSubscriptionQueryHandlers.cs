using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportationSubscriptions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentTransportationSubscriptions;

public class StudentTransportationSubscriptionQueryHandlers : 
    IRequestHandler<GetStudentTransportationSubscriptionByIdQuery, StudentTransportationSubscriptionDto>,
    IRequestHandler<GetAllStudentTransportationSubscriptionsQuery, IEnumerable<StudentTransportationSubscriptionDto>>
{
    private readonly IGenericRepository<StudentTransportationSubscription> _repository;
    private readonly IMapper _mapper;

    public StudentTransportationSubscriptionQueryHandlers(IGenericRepository<StudentTransportationSubscription> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentTransportationSubscriptionDto> Handle(GetStudentTransportationSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentTransportationSubscription not found.");
        return _mapper.Map<StudentTransportationSubscriptionDto>(entity);
    }

    public async Task<IEnumerable<StudentTransportationSubscriptionDto>> Handle(GetAllStudentTransportationSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentTransportationSubscriptionDto>>(entities);
    }
}