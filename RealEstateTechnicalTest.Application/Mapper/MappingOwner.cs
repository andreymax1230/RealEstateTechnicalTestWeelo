using AutoMapper;
using RealEstateTechnicalTest.Application.Owner.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Application.Mapper
{
    public class MappingOwner : Profile
    {
        public MappingOwner()
        {
            CreateMap<Domain.Entities.Owner, OwnerDto>().ReverseMap();
        }
    }
}
