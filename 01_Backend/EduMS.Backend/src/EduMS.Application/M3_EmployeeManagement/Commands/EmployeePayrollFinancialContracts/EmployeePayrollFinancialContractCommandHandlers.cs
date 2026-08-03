using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeePayrollFinancialContracts;

public class EmployeePayrollFinancialContractCommandHandlers : 
    IRequestHandler<CreateEmployeePayrollFinancialContractCommand, long>,
    IRequestHandler<UpdateEmployeePayrollFinancialContractCommand, bool>,
    IRequestHandler<DeleteEmployeePayrollFinancialContractCommand, bool>
{
    private readonly IGenericRepository<EmployeePayrollFinancialContract> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeePayrollFinancialContractCommandHandlers(IGenericRepository<EmployeePayrollFinancialContract> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateEmployeePayrollFinancialContractCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<EmployeePayrollFinancialContract>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateEmployeePayrollFinancialContractCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeePayrollFinancialContract not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteEmployeePayrollFinancialContractCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeePayrollFinancialContract not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}