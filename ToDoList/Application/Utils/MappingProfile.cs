using Application.DTOs;
using Application.Use_Cases.Commands;
using AutoMapper;
using Domain.Entities;


namespace Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoList, ToDoListDto>().ReverseMap();
            CreateMap<CreateToDoListCommand, ToDoList>().ReverseMap();
            //CreateMap<UpdateToDoListCommand, ToDoList>().ReverseMap();
        }
    }
}
