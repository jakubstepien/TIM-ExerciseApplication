﻿using Autofac;
using MobileApp.Services;
using MobileApp.Services.Account;
using MobileApp.Services.Excercise;
using MobileApp.Services.Statistics;
using MobileApp.Services.Training;
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
            RegisterViewModels(builder);
        }

        private void RegisterViews(ContainerBuilder builder)
        {
            builder.RegisterType<Views.MasterDetail.MasterDetailPage>().AsSelf().InstancePerDependency();

            builder.RegisterType<Views.Account.Login>().AsSelf().InstancePerDependency();
            builder.RegisterType<Views.Account.Register>().AsSelf().InstancePerDependency();

            builder.RegisterType<Views.Exercises.ExercisesList>().AsSelf().InstancePerDependency();
            builder.RegisterType<Views.Summary.Summary>().AsSelf().InstancePerDependency();
            builder.RegisterType<Views.Trainings.AddTraining>().AsSelf().InstancePerDependency();
            builder.RegisterType<Views.Trainings.TrainingsList>().AsSelf().InstancePerDependency();

        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerDependency();
            builder.RegisterType<ExcerciseService>().As<IExcerciseService>().InstancePerDependency();
            builder.RegisterType<StatisticsService>().As<IStatisticsService>().InstancePerDependency();
            builder.RegisterType<TrainingService>().As<ITrainingService>().InstancePerDependency();

        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<ViewModels.MasterDetail.MasterDetailPageMasterViewModel>().AsSelf().InstancePerDependency();
        }

    }
}
