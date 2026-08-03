using EduMS.Application.M5_FinancialManagement.DTOs.Vendors;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.Vendors;

public class CreateVendorCommand : IRequest<long>
{
    public CreateVendorDto Dto { get; set; } = new();
}

public class UpdateVendorCommand : IRequest<bool>
{
    public UpdateVendorDto Dto { get; set; } = new();
}

public class DeleteVendorCommand : IRequest<bool>
{
    public long Id { get; set; }
}