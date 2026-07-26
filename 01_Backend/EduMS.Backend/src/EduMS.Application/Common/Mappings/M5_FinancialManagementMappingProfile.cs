using AutoMapper;
using EduMS.Application.M5_FinancialManagement.DTOs.FeePayments;
using EduMS.Domain.Entities;

namespace EduMS.Application.Common.Mappings;

public class M5_FinancialManagementMappingProfile : Profile
{
    public M5_FinancialManagementMappingProfile()
    {
        CreateMap<CreateFeePaymentDto, FeePayment>();
    }
}
