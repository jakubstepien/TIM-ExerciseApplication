using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication
{
    public class AutofacConfig
    {
        public static void RegisterDependecies()
        {
            var builder = new ContainerBuilder();
            RegisterBaseDepenedencies(builder);
            RegisterRepositories(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            // Set the dependency resolver for WebApi2.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }

        private static void RegisterBaseDepenedencies(ContainerBuilder builder)
        {
            var config = GlobalConfiguration.Configuration;

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<Database.ApplicationDbContext>().As<System.Data.Entity.DbContext>().InstancePerRequest();
            builder.RegisterType<Database.Repositories.ExcerciseRepository>().As<Database.Repositories.IExcerciseRepository>().InstancePerRequest();
        }
    }
}