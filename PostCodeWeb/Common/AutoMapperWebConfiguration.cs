using System;
using System.Linq;
using AutoMapper;
using JustEatDataAccess.Models;
using JustEatWeb.ViewModels;

namespace JustEatWeb.Common
{
    public static class AutoMapperWebConfiguration
    {
        public static void ConfigureWebMapping()
        {
            Mapper.CreateMap<Result, PostCodeResultVm>();
        } 
     }
}