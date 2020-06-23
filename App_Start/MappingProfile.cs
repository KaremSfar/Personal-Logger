using AutoMapper;
using PersonalLogger.DTO;
using PersonalLogger.Models;
using Microsoft.AspNet.Identity;
using System.Web;

namespace PersonalLogger.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<FieldType, FieldTypeDTO>();
            Mapper.CreateMap<FieldTypeDTO, FieldType>();

            Mapper.CreateMap<CategoryField, CategoryFieldDTO>();
            Mapper.CreateMap<CategoryFieldDTO, CategoryField>()
                .ForMember(dest => dest.FieldTypeId,
                opts=>opts.MapFrom(src=>src.FieldType.Id));

            Mapper.CreateMap<LogCategory, LogCategoryDTO>();
            Mapper.CreateMap<LogCategoryDTO, LogCategory>();

        }
    }
}