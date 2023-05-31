using AutoMapper;
using FunkoMania.Application.ViewModel;
using FunkoMania.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderViewModel, Order>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(map => map.Address.Id));
        }
    }
}
