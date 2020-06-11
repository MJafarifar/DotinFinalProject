using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common;
using Owin;
using SampleWebApi.Models;
using SampleWebApi.Repositories;
using SampleWebApi.Services;
using WebApiContrib.IoC.Ninject;

[assembly: OwinStartup(typeof(SampleWebApi.Startup))]

namespace SampleWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration
            {
                DependencyResolver = new NinjectResolver(CreateKernel())
            };

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiWithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            app.UseWebApi(config);
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IGenerateLinkRepository>().ToConstant(new GenerateLinkRepository());
            kernel.Bind<IGenerateLink>().To<GenerateLink>().InRequestScope();

            return kernel;
        }
    }
}
