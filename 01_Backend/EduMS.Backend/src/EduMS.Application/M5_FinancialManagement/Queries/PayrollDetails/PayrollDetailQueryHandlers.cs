using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.PayrollDetails;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.PayrollDetails;

public class PayrollDetailQueryHandlers : 
    IRequestHandler<GetPayrollDetailByIdQuery, PayrollDetailDto>,
    IRequestHandler<GetAllPayrollDetailsQuery, IEnumerable<PayrollDetailDto>>
{
    private readonly IGenericRepository<PayrollDetail> _repository;
    private readonly IMapper _mapper;

    public PayrollDetailQueryHandlers(IGenericRepository<PayrollDetail> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PayrollDetailDto> Handle(GetPayrollDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PayrollDetail not found.");
        return _mapper.Map<PayrollDetailDto>(entity);
    }

    public async Task<IEnumerable<PayrollDetailDto>> Handle(GetAllPayrollDetailsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PayrollDetailDto>>(entities);
    }
}