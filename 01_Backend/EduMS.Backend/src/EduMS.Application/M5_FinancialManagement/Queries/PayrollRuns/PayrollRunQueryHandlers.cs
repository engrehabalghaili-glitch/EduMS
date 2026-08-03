using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.PayrollRuns;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.PayrollRuns;

public class PayrollRunQueryHandlers : 
    IRequestHandler<GetPayrollRunByIdQuery, PayrollRunDto>,
    IRequestHandler<GetAllPayrollRunsQuery, IEnumerable<PayrollRunDto>>
{
    private readonly IGenericRepository<PayrollRun> _repository;
    private readonly IMapper _mapper;

    public PayrollRunQueryHandlers(IGenericRepository<PayrollRun> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PayrollRunDto> Handle(GetPayrollRunByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PayrollRun not found.");
        return _mapper.Map<PayrollRunDto>(entity);
    }

    public async Task<IEnumerable<PayrollRunDto>> Handle(GetAllPayrollRunsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PayrollRunDto>>(entities);
    }
}