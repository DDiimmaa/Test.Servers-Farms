using AutoMapper;
using Entity = Test.Models.Entities;
using Dto = Test.Models.Dto;

namespace Test.BackEnd
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entity.Server, Dto.Server>();
                cfg.CreateMap<Entity.Farm, Dto.Farm>();
            });
        }
    }
}