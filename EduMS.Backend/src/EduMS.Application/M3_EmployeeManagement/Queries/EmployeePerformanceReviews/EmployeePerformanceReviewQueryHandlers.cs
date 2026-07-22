using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePerformanceReviews;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeePerformanceReviews;

public class EmployeePerformanceReviewQueryHandlers : 
    IRequestHandler<GetEmployeePerformanceReviewByIdQuery, EmployeePerformanceReviewDto>,
    IRequestHandler<GetAllEmployeePerformanceReviewsQuery, IEnumerable<EmployeePerformanceReviewDto>>
{
    private readonly IGenericRepository<EmployeePerformanceReview> _repository;
    private readonly IMapper _mapper;

    public EmployeePerformanceReviewQueryHandlers(IGenericRepository<EmployeePerformanceReview> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeePerformanceReviewDto> Handle(GetEmployeePerformanceReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeePerformanceReview not found.");
        return _mapper.Map<EmployeePerformanceReviewDto>(entity);
    }

    public async Task<IEnumerable<EmployeePerformanceReviewDto>> Handle(GetAllEmployeePerformanceReviewsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeePerformanceReviewDto>>(entities);
    }
}