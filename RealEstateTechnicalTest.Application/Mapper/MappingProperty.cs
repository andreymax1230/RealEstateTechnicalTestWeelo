using AutoMapper;
using RealEstateTechnicalTest.Application.Property.Commands;
using RealEstateTechnicalTest.Application.Property.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Application.Mapper
{
    public class MappingProperty : Profile
    {
        public MappingProperty()
        {
            CreateMap<Domain.Entities.Property, CreatePropertyCommand>().ReverseMap();
            CreateMap<Domain.Entities.Property, UpdatePropertyCommand>().ReverseMap();
            CreateMap<Domain.Entities.Property, PropertyDto>().ReverseMap();
        }
    }
}
