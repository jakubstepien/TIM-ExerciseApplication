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
using WebApplication.Services;

namespace WebApplication
{
    public class AutofacConfig
    {
        public static void RegisterDependecies()
        {
            var builder = new ContainerBuilder();
            RegisterBaseDepenedencies(builder);
            RegisterRepositories(builder);
            RegisterServices(builder);

            var container = builder.Build();
            
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;


            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }

        private static void RegisterBaseDepenedencies(ContainerBuilder builder)
        {
            var config = GlobalConfiguration.Configuration;


            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<Database.ApplicationDbContext>().As<System.Data.Entity.DbContext>().InstancePerRequest();
            builder.RegisterType<Database.Repositories.ExcerciseRepository>().As<Database.Repositories.IExcerciseRepository>().InstancePerRequest();
            builder.RegisterType<Database.Repositories.UserExcerciseRepository>().As<Database.Repositories.IUserExcerciseRepository>().InstancePerRequest();
            builder.RegisterType<Database.Repositories.StatisticRepository>().As<Database.Repositories.IStatisticRepository>().InstancePerRequest();
            builder.RegisterType<Database.Repositories.TrainingRepository>().As<Database.Repositories.ITrainingRepository>().InstancePerRequest();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ImageService>().AsSelf().InstancePerRequest();
        }
    }
}