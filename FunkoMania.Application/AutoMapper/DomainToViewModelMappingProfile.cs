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
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Address, AddressViewModel>()
                .ReverseMap();
            CreateMap<Client, ClientViewModel>()
                .ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();

            CreateMap<Order, OrderViewModel>();

            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
        }
    }
}
