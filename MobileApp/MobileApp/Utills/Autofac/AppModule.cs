using Autofac;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Utills.Autofac
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterViews(builder);
            RegisterServices(builder);
        }

        private void RegisterViews(ContainerBuilder builder)
        {
            builder.RegisterType<Views.MasterDetail.MasterDetailPage>().AsSelf().InstancePerDependency();

            builder.RegisterType<Views.Exercises.ExercisesList>().AsSelf().InstancePerDependency();
            builder.RegisterType<Views.Summary.Summary>().AsSelf().InstancePerDependency();
            builder.RegisterType<Views.Trainings.AddTraining>().AsSelf().InstancePerDependency();
            builder.RegisterType<Views.Trainings.TrainingsList>().AsSelf().InstancePerDependency();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>().As<ITestService>().InstancePerDependency();
        }


    }
}
