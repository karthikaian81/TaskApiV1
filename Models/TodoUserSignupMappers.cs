using AutoMapper;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.Models
{
    public class TodoUserSignupMappers : Profile
    {
        public TodoUserSignupMappers()
        {
            CreateMap<TodoUserSignupCreate, TodoUserSignupFormat>()
                .ForMember(x => x.PasswordHash, (opt) =>
                {
                   // opt.MapFrom()
                });
        }
    }
}
