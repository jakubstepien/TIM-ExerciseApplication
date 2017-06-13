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

namespace WebApplication.Controllers.Api
{
    [RoutePrefix("api/exercises")]
    public class ExercisesController : ApiController
    {
        private ExcerciseRepository db;

        public ExercisesController(ExcerciseRepository db)
        {
            this.db = db;
        }

        // GET: api/Exercises
        public IQueryable<Exercise> GetExercise()
        {
            return db.GetAll();
        }

        [Route("user/{userId}")]
        public IQueryable<Exercise> GetExerciseForUser(Guid userId)
        {
            return db.GetAll();
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult GetExercise(Guid id)
        {
            Exercise exercise = db.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise(Guid id, Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.IdExercise)
            {
                return BadRequest();
            }

            db.Update(exercise);

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
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult PostExercise(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(exercise);

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

            return CreatedAtRoute("DefaultApi", new { id = exercise.IdExercise }, exercise);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult DeleteExercise(Guid id)
        {
            Exercise exercise = db.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Remove(exercise);
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