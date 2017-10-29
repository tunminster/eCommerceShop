using AutoMapper;
using eCommerceShop.Core.Models;
using eCommerceShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceShop.Web.App_Start
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ModelsProfile()));
        }
    }

    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            base.CreateMap<CustomerModel, Customer>().ReverseMap();
        }
    }
}