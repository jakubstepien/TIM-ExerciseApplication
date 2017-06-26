using MobileApp.Models;
using MobileApp.Services.Excercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Utills
{
    class TrainingSlideCreator
    {
        IExcerciseService excerciseService;

        public TrainingSlideCreator(IExcerciseService excerciseService)
        {
            this.excerciseService = excerciseService;
        }

        public async Task<Slide[]> CreateSlides(TrainingModel training)
        {
            List<Slide> slides = new List<Slide>();
            await Task.Factory.StartNew(() =>
            {
                int time = 0;
                for (int j = 0; j < training.Exercises.Length; j++)
                {
                    var exer = training.Exercises[j];
                    for (int i = 0; i < exer.SeriesNumber; i++)
                    {
                        time += exer.SeriesTime;
                        var exerSlide = new Slide
                        {
                            CurrentExerciseName = exer.Name,
                            Image = excerciseService.GetImageSource(exer.Id, exer.ImageName),
                            Series = "Seria " + (i + 1) + "/" + exer.SeriesNumber,
                            Status = (j + 1).ToString() + "/" + training.Exercises.Length,
                            Time = time
                        };
                        slides.Add(exerSlide);
                        if (i == exer.SeriesNumber - 1)
                        {
                            break;
                        }
                        time += exer.Interval;
                        var intervalSlide = new Slide
                        {
                            CurrentExerciseName = exer.Name,
                            Image = excerciseService.GetImageSource(exer.Id, exer.ImageName),
                            Series = "Przerwa, następna seria -  " + (i + 2) + "/" + exer.SeriesNumber,
                            Status = (j + 1).ToString() + "/" + training.Exercises.Length,
                            Time = time
                        };
                        slides.Add(intervalSlide);
                    }
                    if (j == training.Exercises.Length - 1)
                    {
                        break;
                    }
                    var next = training.Exercises[j + 1];
                    time += exer.NextExerciseInterval;
                    var breakSlide = new Slide
                    {
                        CurrentExerciseName = "Przerwa",
                        Image = excerciseService.GetImageSource(next.Id, next.ImageName),
                        Series = "Następne ćwiczenie - " + next.Name,
                        Status = (j + 1).ToString() + "/" + training.Exercises.Length,
                        Time = time
                    };
                    slides.Add(breakSlide);
                }
            });
            return slides.ToArray();
        }
    }
}
