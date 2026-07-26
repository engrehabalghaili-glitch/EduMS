using AutoMapper;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetAssignments;
using EduMS.Domain.Entities;

namespace EduMS.Application.Common.Mappings;

public class M4_AssetLogisticsMappingProfile : Profile
{
    public M4_AssetLogisticsMappingProfile()
    {
        CreateMap<CreateAssetAssignmentDto, AssetAssignment>();
    }
}
