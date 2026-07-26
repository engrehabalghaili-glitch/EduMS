using AutoMapper;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemUsers;
using EduMS.Domain.Entities;

namespace EduMS.Application.Common.Mappings
{
    public class M8_AuthenticationUsersMappingProfile : Profile
    {
        public M8_AuthenticationUsersMappingProfile()
        {
            CreateMap<CreateSystemUserDto, SystemUser>();
            CreateMap<UpdateSystemUserDto, SystemUser>();
            CreateMap<SystemUser, SystemUserDto>();
        }
    }
}
