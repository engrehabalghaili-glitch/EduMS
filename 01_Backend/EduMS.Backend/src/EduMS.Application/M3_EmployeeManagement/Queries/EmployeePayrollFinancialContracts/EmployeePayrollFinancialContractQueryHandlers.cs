using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrollFinancialContracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeePayrollFinancialContracts;

public class EmployeePayrollFinancialContractQueryHandlers : 
    IRequestHandler<GetEmployeePayrollFinancialContractByIdQuery, EmployeePayrollFinancialContractDto>,
    IRequestHandler<GetAllEmployeePayrollFinancialContractsQuery, IEnumerable<EmployeePayrollFinancialContractDto>>
{
    private readonly IGenericRepository<EmployeePayrollFinancialContract> _repository;
    private readonly IMapper _mapper;

    public EmployeePayrollFinancialContractQueryHandlers(IGenericRepository<EmployeePayrollFinancialContract> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeePayrollFinancialContractDto> Handle(GetEmployeePayrollFinancialContractByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeePayrollFinancialContract not found.");
        return _mapper.Map<EmployeePayrollFinancialContractDto>(entity);
    }

    public async Task<IEnumerable<EmployeePayrollFinancialContractDto>> Handle(GetAllEmployeePayrollFinancialContractsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeePayrollFinancialContractDto>>(entities);
    }
}