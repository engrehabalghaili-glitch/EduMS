using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeInstallments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeInstallments;

public class FeeInstallmentQueryHandlers : 
    IRequestHandler<GetFeeInstallmentByIdQuery, FeeInstallmentDto>,
    IRequestHandler<GetAllFeeInstallmentsQuery, IEnumerable<FeeInstallmentDto>>
{
    private readonly IGenericRepository<FeeInstallment> _repository;
    private readonly IMapper _mapper;

    public FeeInstallmentQueryHandlers(IGenericRepository<FeeInstallment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FeeInstallmentDto> Handle(GetFeeInstallmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FeeInstallment not found.");
        return _mapper.Map<FeeInstallmentDto>(entity);
    }

    public async Task<IEnumerable<FeeInstallmentDto>> Handle(GetAllFeeInstallmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FeeInstallmentDto>>(entities);
    }
}