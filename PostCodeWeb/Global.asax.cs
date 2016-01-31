using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PostCodeDataAccess.DataAccess;
using PostCodeWeb.Common;
using PostCodeWeb.ViewModels;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;
using System.Data;
using PostCodeDataAccess.Models.General;

namespace PostCodeWeb
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
            container.RegisterPerWebRequest<IDataReader<GeneralDetails>, GeneralApiDataReader>();
            container.Verify();
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
