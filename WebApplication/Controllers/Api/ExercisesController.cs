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
using ApiClients.Model.DTO;
using WebApplication.Helpers;
using WebApplication.Services;
using System.Web;

namespace WebApplication.Controllers.Api
{
    [RoutePrefix("api/exercises")]
    public class ExercisesController : ApiController
    {
        private IExcerciseRepository db;
        ImageService imageService;

        public ExercisesController(IExcerciseRepository db, ImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }


        // GET: api/Exercises
        public IEnumerable<ExerciseDTO> GetExercise()
        {
            var exercises = db.GetAll()
                .Select(s => new ExerciseDTO
                {
                    IdExercise = s.IdExercise,
                    CaloriesPerHour = s.CaloriesPerHour,
                    Description = s.Description,
                    Image = s.Image,
                    Name = s.Name,
                    ImageName = s.ImageName
                }).ToList();

            exercises.ForEach(f => SaveExerciseImageToDrive(f));
            return exercises;
        }

        [Route("user/{userId}")]
        public IEnumerable<ExerciseDTO> GetExerciseForUser(Guid userId)
        {
            return db.GetExercisesForUser(userId).Select(s => s.ToDTO());
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(ExerciseDTO))]
        public IHttpActionResult GetExercise(Guid id)
        {
            Exercise exercise = db.GetById(id);
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
            var oldEntity = db.GetById(id, true);
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
            db.Update(entity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.Exists(id))
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
            db.Add(exerciseEntity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (db.Exists(exercise.IdExercise))
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
            Exercise exercise = db.GetById(id);
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
                    db.Remove(exercise);
                }
            }
            else
            {
                return BadRequest();
            }
            db.SaveChanges();

            return Ok(exercise);
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}