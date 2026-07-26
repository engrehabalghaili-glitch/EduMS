using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.Vendors;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.Vendors;

public class VendorQueryHandlers : 
    IRequestHandler<GetVendorByIdQuery, VendorDto>,
    IRequestHandler<GetAllVendorsQuery, IEnumerable<VendorDto>>
{
    private readonly IGenericRepository<Vendor> _repository;
    private readonly IMapper _mapper;

    public VendorQueryHandlers(IGenericRepository<Vendor> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VendorDto> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Vendor not found.");
        return _mapper.Map<VendorDto>(entity);
    }

    public async Task<IEnumerable<VendorDto>> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<VendorDto>>(entities);
    }
}