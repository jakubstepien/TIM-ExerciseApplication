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

namespace WebApplication.Controllers.Api
{
    [RoutePrefix("api/exercises")]
    public class ExercisesController : ApiController
    {
        private IExcerciseRepository db;

        public ExercisesController(IExcerciseRepository db)
        {
            this.db = db;
        }

        // GET: api/Exercises
        public IEnumerable<ExerciseDTO> GetExercise()
        {
            return db.GetAll()
                .Select(s => new ExerciseDTO
                {
                    IdExercise = s.IdExercise,
                    CaloriesPerHour = s.CaloriesPerHour,
                    Description = s.Description,
                    Image = s.Image,
                    Name = s.Name
                });
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

            return Ok(exercise.ToDTO());
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise(Guid id, ExerciseDTO exercise)
        {
            var entity = exercise.ToEntity();
            Validate(entity);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.IdExercise)
            {
                return BadRequest();
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
            var exerciseEntity = exercise.ToEntity();
            exerciseEntity.UserExcercise.Add(new UserExcercise { UserId = userId });
            Validate(exerciseEntity);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
        public IHttpActionResult DeleteExerciseFromUser(Guid id,Guid userId)
        {
            Exercise exercise = db.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }
            if(exercise.UserExcercise.Any(a => a.UserId == userId))
            {
                if(exercise.UserExcercise.Count != 1)
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