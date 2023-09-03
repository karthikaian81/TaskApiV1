using AutoMapper;
using TaskApiV1.Models.BuisnessModels;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.Models
{
    public class TodoUserMappers : Profile
    {
        public TodoUserMappers() 
        {
            CreateMap<TodoUserCreate, TodoUsersAppFormat>()
                .ForMember(dest => dest.RoleId,
                opt => opt.MapFrom(src => new UsersRoles().GetRoleId(src.RoleName)))
                .ForMember(dest => dest.Active,
                opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.UserLoginName,
                opt => opt.MapFrom(src => 
                string.IsNullOrEmpty(src.LoginName) ? src.FirstName +src.LastName : src.LoginName));

            CreateMap<TodoUserUpdate, TodoUsersAppFormat>()
               .ForMember(dest => dest.RoleId,
               opt => opt.MapFrom(src => new UsersRoles().GetRoleId(src.RoleName)))
               .ForMember(dest => dest.UserLoginName,
               opt => opt.MapFrom(src =>
               string.IsNullOrEmpty(src.LoginName) ? src.FirstName + src.LastName : src.LoginName));

            CreateMap<TodoUserGet, TodoUsersAppFormat>().ReverseMap()
               .ForMember(dest => dest.RoleName,
               opt => opt.MapFrom(src => new UsersRoles().GetRoleName(src.RoleId)))
               .ForMember(dest => dest.DateofBirth,opt => opt.MapFrom(src => src.DOB))
               .ForMember(dest => dest.Email,
               opt => opt.MapFrom(src => src.UserEmail) )
                .ForMember(dest => dest.LoginName,
                 opt => opt.MapFrom(src =>
                //string.IsNullOrEmpty(src.UserLoginName) ? src.FirstName + src.LastName :
                src.UserLoginName));




        }

        
    }
}
