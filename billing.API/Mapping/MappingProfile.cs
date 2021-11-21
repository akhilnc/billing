using AutoMapper;
using billing.Data.DTOs.Masters;
using billing.Data.Models;

namespace billing.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<MstUser, UserDTO>();
            CreateMap<MstUserRole, UserRoleDTO>();

            // DTO to Entity
            CreateMap<UserDTO, MstUser>();
            CreateMap<UserRoleDTO, MstUserRole>();
        }
    }
}