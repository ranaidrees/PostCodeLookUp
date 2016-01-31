using System;
using System.Linq;
using AutoMapper;
using PostCodeDataAccess.Models;
using PostCodeWeb.ViewModels;
using PostCodeDataAccess.Models.General;

namespace PostCodeWeb.Common
{
    public static class AutoMapperWebConfiguration
    {
        public static void ConfigureWebMapping()
        {
            Mapper.CreateMap<Result, PostCodeResultVm>();
        } 
     }
}