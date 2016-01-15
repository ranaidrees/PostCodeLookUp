using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using JustEatDataAccess;
using JustEatDataAccess.DataAccess;
using JustEatDataAccess.Models;
using JustEatWeb.Common;
using JustEatWeb.ViewModels;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;

namespace JustEatWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperWebConfiguration.ConfigureWebMapping();

            // Create the container as usual for Simple injector(dependency injection).
            var container = new Container();
            // Register your types, for instance:
            container.RegisterPerWebRequest<IDataReader, PostCodeApiDataReader>();
            container.Verify();
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
