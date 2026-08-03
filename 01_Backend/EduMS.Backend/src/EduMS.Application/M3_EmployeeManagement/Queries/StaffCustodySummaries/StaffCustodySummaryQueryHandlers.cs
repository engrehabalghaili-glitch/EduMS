using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.StaffCustodySummaries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.StaffCustodySummaries;

public class StaffCustodySummaryQueryHandlers : 
    IRequestHandler<GetStaffCustodySummaryByIdQuery, StaffCustodySummaryDto>,
    IRequestHandler<GetAllStaffCustodySummariesQuery, IEnumerable<StaffCustodySummaryDto>>
{
    private readonly IGenericRepository<StaffCustodySummary> _repository;
    private readonly IMapper _mapper;

    public StaffCustodySummaryQueryHandlers(IGenericRepository<StaffCustodySummary> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StaffCustodySummaryDto> Handle(GetStaffCustodySummaryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StaffCustodySummary not found.");
        return _mapper.Map<StaffCustodySummaryDto>(entity);
    }

    public async Task<IEnumerable<StaffCustodySummaryDto>> Handle(GetAllStaffCustodySummariesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StaffCustodySummaryDto>>(entities);
    }
}