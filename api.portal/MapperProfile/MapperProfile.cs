using Api.Portal.BusinessLayer.Model;
using Api.Portal.DataLayer.Repository.Entity;
using Api.Portal.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Portal.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreditCardDto, CreditCardModel>();
            CreateMap<CreditCardModel, CreditCardEntity>();
        }
    }
}
