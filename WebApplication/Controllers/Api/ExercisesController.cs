using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Database;
using Database.Repositories;
using WebApplication.Models;
using ApiClients.Models.DTO;
using WebApplication.Helpers;
using WebApplication.Services;
using System.Web;
using Microsoft.AspNet.Identity;
using ApiClients.Models.Account;
using ApiClients.Models;
using Database.Repositories.Excercise;
using Database.Repositories.UserExcercise;
using Database.Repositories.Statistic;

namespace WebApplication.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/exercises")]
    public class ExercisesController : ApiController
    {
        private IExcerciseRepository excerciseRepo;
        private IUserExcerciseRepository userExerciseRepo;
        private IStatisticRepository statisticsRepo;
        ImageService imageService;

        public ExercisesController(IExcerciseRepository excerciseRepo, IUserExcerciseRepository userExerciseRepo, IStatisticRepository statisticsRepo, ImageService imageService)
        {
            this.excerciseRepo = excerciseRepo;
            this.userExerciseRepo = userExerciseRepo;
            this.statisticsRepo = statisticsRepo;
            this.imageService = imageService;
        }

        // GET: api/Exercises
        public IEnumerable<ExerciseDTO> GetExercise()
        {
            var exercises = excerciseRepo.GetAll()
                .Select(s => new ExerciseDTO
                {
                    IdExercise = s.IdExercise,
                    CaloriesPerHour = s.CaloriesPerHour,
                    Description = s.Description,
                    Image = s.Image,
                    Name = s.Name,
                    ImageName = s.ImageName
                }).ToList();

            exercises.ForEach(f =>
            {
                SaveExerciseImageToDrive(f);
                //nie ma po co przesyłąc zawsze całego obrazu
                f.Image = null;
            });
            return exercises;
        }

        [Route("user/{userId}")]
        public PagedList<ExerciseDTO> GetExerciseForUser(Guid userId, int page = 1, int pageSize = int.MaxValue)
        {
            var exercises = excerciseRepo.GetExercisesForUser(userId, page, pageSize).Select(s => s.ToDTO()).ToArray();
            foreach (var exercise in exercises)
            {
                SaveExerciseImageToDrive(exercise);
                //nie ma po co przesyłąc zawsze całego obrazu
                exercise.Image = null;
            }
            var total = excerciseRepo.Count(e => e.UserExcercise.Any(a => a.UserId == userId));
            return new PagedList<ExerciseDTO> { CurrentPage = page, PageSize = pageSize, Items = exercises, TotalCount = total };
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(ExerciseDTO))]
        public IHttpActionResult GetExercise(Guid id)
        {
            Exercise exercise = excerciseRepo.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }
            SaveExerciseImageToDrive(exercise);
            return Ok(exercise.ToDTO());
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise(Guid id, ExerciseDTO exercise)
        {
            var entity = exercise.ToEntity();
            var oldEntity = excerciseRepo.GetById(id, true);
            Validate(entity);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.IdExercise)
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(exercise.ImageName))
            {
                entity.Image = imageService.GetImageBytes(new HttpServerUtilityWrapper(HttpContext.Current.Server), exercise.IdExercise, exercise.ImageName);
            }
            else
            {
                entity.Image = oldEntity.Image;
                entity.ImageName = oldEntity.ImageName;
            }
            excerciseRepo.Update(entity);

            try
            {
                excerciseRepo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!excerciseRepo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Exercises
        [Route("user/{userId}/")]
        [ResponseType(typeof(ExerciseDTO))]
        public IHttpActionResult PostExercise(Guid userId, ExerciseDTO exercise)
        {
            if (exercise.IdExercise == Guid.Empty)
            {
                exercise.IdExercise = Guid.NewGuid();
            }
            var exerciseEntity = exercise.ToEntity();
            exerciseEntity.UserExcercise.Add(new UserExcercise { UserId = userId });
            Validate(exerciseEntity);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!string.IsNullOrEmpty(exercise.ImageName))
            {
                exerciseEntity.Image = imageService.GetImageBytes(new HttpServerUtilityWrapper(HttpContext.Current.Server), exercise.IdExercise, exercise.ImageName);
            }
            excerciseRepo.Add(exerciseEntity);

            try
            {
                excerciseRepo.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (excerciseRepo.Exists(exercise.IdExercise))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(exercise);
        }

        // DELETE: api/Exercises/5
        [Route("{id}/user/{userId}/")]
        [ResponseType(typeof(ExerciseDTO))]
        public IHttpActionResult DeleteExerciseFromUser(Guid id, Guid userId)
        {
            Exercise exercise = excerciseRepo.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }
            if (exercise.UserExcercise.Any(a => a.UserId == userId))
            {
                if (exercise.UserExcercise.Count != 1)
                {
                    exercise.UserExcercise = exercise.UserExcercise.Where(W => W.UserId != userId).ToArray();
                }
                else
                {
                    excerciseRepo.Remove(exercise);
                }
            }
            else
            {
                return BadRequest();
            }
            excerciseRepo.SaveChanges();

            return Ok(exercise);
        }

        [HttpPost]
        [Route("favourite/{id}/user/{userId}/")]
        public IHttpActionResult FavouriteExercise(Guid id, Guid userId)
        {
            try
            {
                var userExcercise = userExerciseRepo.Get(userId, id);
                userExcercise.IsFavourite = !userExcercise.IsFavourite;
                userExerciseRepo.SaveChanges();
                return Ok(userExcercise.IsFavourite);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("finished/user/{userId}/")]
        public IHttpActionResult PostFinishedExercise(Guid userId, FinishedExerciseDTO exercise)
        {
            statisticsRepo.Add(new Statistic
            {
                Callories = exercise.Callories,
                Date = exercise.Date,
                ExerciseName = exercise.Name,
                IdUser = exercise.UserId,
                IdStatistic = Guid.NewGuid()
            });
            statisticsRepo.SaveChanges();
            return Ok();
        }

        [Route("statistics/user/{userId}/")]
        public IEnumerable<FinishedExerciseDTO> PostFinishedExerciseByDate(Guid userId, FinishedExerciseRequest request)
        {
            var finishedExcercises = statisticsRepo.GetAllBetweenDate(request.After, request.Before).Select(s => new FinishedExerciseDTO
            {
                Date = s.Date,
                Callories = s.Callories,
                Name = s.ExerciseName,
                UserId = s.IdUser
            });
            return finishedExcercises;
        }

        private void SaveExerciseImageToDrive(ExerciseDTO exercise)
        {
            imageService.SaveImage(new HttpServerUtilityWrapper(HttpContext.Current.Server), exercise.Image, exercise.IdExercise, exercise.ImageName);
        }

        private void SaveExerciseImageToDrive(Exercise exercise)
        {
            imageService.SaveImage(new HttpServerUtilityWrapper(HttpContext.Current.Server), exercise.Image, exercise.IdExercise, exercise.ImageName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                excerciseRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}