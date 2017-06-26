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
                    Id = s.Id,
                    IdTraining = training.IdTraining,
                    IdExercise = s.IdExcercise,
                    Interval = s.Interval,
                    Series = s.Series,
                    IntervalBeforeNextExercise = s.IntervalBeforeNextExercise,
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
                    Id = s.Id,
                    IdExcercise = s.IdExercise,
                    Interval = s.Interval,
                    Series = s.Series,
                    TimeSpan = s.TimeSpan,
                    IntervalBeforeNextExercise = s.IntervalBeforeNextExercise,
                    CalloriesPerHour = s.Excercise?.CaloriesPerHour,
                    ImageName = s.Excercise?.ImageName,
                    Name = s.Excercise?.Name
                }).ToArray()
            };
        }
    }
}