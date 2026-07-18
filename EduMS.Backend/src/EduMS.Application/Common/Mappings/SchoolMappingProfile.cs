using AutoMapper;
using EduMS.Application.M1_SchoolAdmin.DTOs.Schools;
using EduMS.Domain.Entities;

namespace EduMS.Application.Common.Mappings;

public class SchoolMappingProfile : Profile
{
    public SchoolMappingProfile()
    {
        // Domain Entity to DTO
        CreateMap<School, SchoolDto>()
            .ForMember(dest => dest.SyncStatus, opt => opt.MapFrom(src => src.SyncStatus.ToString()));

        // Create DTO to Domain Entity
        CreateMap<CreateSchoolDto, School>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.VersionToken, opt => opt.Ignore())
            .ForMember(dest => dest.SyncStatus, opt => opt.Ignore())
            .ForMember(dest => dest.LastSyncedAt, opt => opt.Ignore());

        // Update DTO to Domain Entity
        CreateMap<UpdateSchoolDto, School>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.VersionToken, opt => opt.Ignore())
            .ForMember(dest => dest.SyncStatus, opt => opt.Ignore())
            .ForMember(dest => dest.LastSyncedAt, opt => opt.Ignore())
            .ForMember(dest => dest.DirectorateId, opt => opt.Ignore())
            .ForMember(dest => dest.EducationalStageId, opt => opt.Condition(src => src.EducationalStageId.HasValue));
    }

}
