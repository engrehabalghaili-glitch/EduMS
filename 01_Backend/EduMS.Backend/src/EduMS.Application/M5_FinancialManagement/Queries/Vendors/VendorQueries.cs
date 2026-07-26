using EduMS.Application.M5_FinancialManagement.DTOs.Vendors;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.Vendors;

public class GetVendorByIdQuery : IRequest<VendorDto>
{
    public long Id { get; set; }
}

public class GetAllVendorsQuery : IRequest<IEnumerable<VendorDto>>
{
}