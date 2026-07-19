using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Commands.Accounts;

public class AccountCommandHandlers : 
    IRequestHandler<CreateAccountCommand, long>,
    IRequestHandler<UpdateAccountCommand, bool>,
    IRequestHandler<DeleteAccountCommand, bool>
{
    private readonly IGenericRepository<Account> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AccountCommandHandlers(IGenericRepository<Account> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Account>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Account not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Account not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}