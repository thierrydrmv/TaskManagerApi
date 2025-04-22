using TaskManagerApi.Application.DTOs;
using TaskManagerApi.Domain.Entities;
using AutoMapper;

namespace TaskManagerApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppTask, AppTaskDto>();
            CreateMap<CreateAppTaskDto, AppTask>();
            CreateMap<UpdateAppTaskDto, AppTask>();
            CreateMap<AppTask, UpdateAppTaskDto>();
        }
    }
}
