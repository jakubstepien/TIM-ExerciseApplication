using ApiClients.Models.DTO;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Helpers
{
    public static class TrainingHelper
    {
        public static Training ToEntity(this TrainingDTO training)
        {
            return new Training
            {
                IdTraining = training.IdTraining,
                IdUser = training.IdUser,
                Name = training.Name,
                Excercises = training.Excercises.Select(s => new TrainingExcercise
                {
                    IdTraining = training.IdTraining,
                    IdExercise = s.IdExcercise,
                    Interval = s.Interval,
                    Series = s.Series,
                    TimeSpan = s.TimeSpan
                }).ToArray()
            };
        }

        public static TrainingDTO ToDTO(this Training training)
        {
            return new TrainingDTO
            {
                IdTraining = training.IdTraining,
                IdUser = training.IdUser,
                Name = training.Name,
                Excercises = training.Excercises.Select(s => new TrainingExcerciseDTO
                {
                    IdExcercise = s.IdExercise,
                    Interval = s.Interval,
                    Series = s.Series,
                    TimeSpan = s.TimeSpan
                }).ToArray()
            };
        }
    }
}