using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static AutoMapperConfig RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
                //Teste
            });
        }
    }
}
