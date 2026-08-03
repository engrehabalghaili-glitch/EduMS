using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeePayments;

public class FeePaymentCommandHandlers : 
    IRequestHandler<CreateFeePaymentCommand, long>,
    IRequestHandler<UpdateFeePaymentCommand, bool>,
    IRequestHandler<DeleteFeePaymentCommand, bool>
{
    private readonly IGenericRepository<FeePayment> _repository;
    private readonly IGenericRepository<StudentInvoice> _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FeePaymentCommandHandlers(
        IGenericRepository<FeePayment> repository,
        IGenericRepository<StudentInvoice> invoiceRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateFeePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<FeePayment>(request.Dto);
        
        if (entity.InvoiceId.HasValue)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(entity.InvoiceId.Value, cancellationToken);
            if (invoice != null)
            {
                invoice.PaidAmount += entity.Amount;
                invoice.RemainingAmount = invoice.TotalAmount - invoice.PaidAmount - invoice.DiscountAmount;
                if (invoice.RemainingAmount < 0) invoice.RemainingAmount = 0; // Handle overpayment gracefully
                
                invoice.PaymentStatus = invoice.RemainingAmount <= 0 ? 3 : 2; // 3=FullyPaid, 2=PartiallyPaid
                await _invoiceRepository.UpdateAsync(invoice, cancellationToken);
            }
        }

        await _repository.AddAsync(entity, cancellationToken);
        
        entity.AddDomainEvent(new EduMS.Domain.Events.PaymentReceivedEvent(
            entity.Id, // Might be 0 if DB generated
            entity.StudentId,
            entity.Amount,
            entity.PaymentDate
        ));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateFeePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FeePayment not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteFeePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FeePayment not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}