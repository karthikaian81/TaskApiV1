using AutoMapper;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.Models
{
    public class TodoTestMappers : Profile
    {
        public TodoTestMappers()
        {
            CreateMap<TodoTestcreate, TestTodoAppFormat>();
            CreateMap<TodoTestUpdate, TestTodoAppFormat>().ForMember(dest => dest.TaskId ,opt=>opt.Ignore());
            CreateMap<TodoTestGet   , TestTodoAppFormat>().ReverseMap().ForMember(dest => dest.Id,opt => opt.MapFrom(src=>src.TaskId));
        }
    }
}
