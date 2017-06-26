using ApiClients.Model.DTO;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Helpers
{
    public static class ExerciseHelper
    {
        public static ExerciseDTO ToDTO(this Exercise exercise)
        {
            return new ExerciseDTO
            {
                CaloriesPerHour = exercise.CaloriesPerHour,
                Description = exercise.Description,
                IdExercise = exercise.IdExercise,
                Image = exercise.Image,
                Name = exercise.Name,
                ImageName = exercise.ImageName,
            };
        }

        public static Exercise ToEntity(this ExerciseDTO exercise)
        {
            return new Exercise
            {
                CaloriesPerHour = exercise.CaloriesPerHour,
                Description = exercise.Description,
                IdExercise = exercise.IdExercise,
                Image = exercise.Image,
                Name = exercise.Name,
                ImageName = exercise.ImageName
            };
        }

        public static ExerciseDTO ToDTO(this UserExcercise exercise)
        {
            return new ExerciseDTO
            {
                CaloriesPerHour = exercise.Exercise.CaloriesPerHour,
                Description = exercise.Exercise.Description,
                IdExercise = exercise.Exercise.IdExercise,
                Image = exercise.Exercise.Image,
                Name = exercise.Exercise.Name,
                ImageName = exercise.Exercise.ImageName,
                IsFavourite = exercise.IsFavourite
            };
        }
    }
}