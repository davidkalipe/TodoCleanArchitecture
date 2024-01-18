using AutoMapper;
using Todo.Application.DTOs;

namespace Todo.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Core.Domain.Models.Todo, TodoDto>().ReverseMap();
    }
}