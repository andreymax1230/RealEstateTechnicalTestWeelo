using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Application.Mapper
{
    public class MapperConfig
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingOwner>();
                cfg.AddProfile<MappingProperty>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
