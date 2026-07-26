using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.StudentInvoices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.StudentInvoices;

public class StudentInvoiceQueryHandlers : 
    IRequestHandler<GetStudentInvoiceByIdQuery, StudentInvoiceDto>,
    IRequestHandler<GetAllStudentInvoicesQuery, IEnumerable<StudentInvoiceDto>>
{
    private readonly IGenericRepository<StudentInvoice> _repository;
    private readonly IMapper _mapper;

    public StudentInvoiceQueryHandlers(IGenericRepository<StudentInvoice> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentInvoiceDto> Handle(GetStudentInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentInvoice not found.");
        return _mapper.Map<StudentInvoiceDto>(entity);
    }

    public async Task<IEnumerable<StudentInvoiceDto>> Handle(GetAllStudentInvoicesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentInvoiceDto>>(entities);
    }
}