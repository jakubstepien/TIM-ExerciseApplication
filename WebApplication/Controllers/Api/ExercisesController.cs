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

namespace WebApplication.Controllers.Api
{
    public class ExercisesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Exercises
        public IQueryable<Exercise> GetExercise()
        {
            return db.Exercise;
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult GetExercise(Guid id)
        {
            Exercise exercise = db.Exercise.Find(id);
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

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

            db.Exercise.Add(exercise);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExerciseExists(exercise.IdExercise))
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
            Exercise exercise = db.Exercise.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercise.Remove(exercise);
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

        private bool ExerciseExists(Guid id)
        {
            return db.Exercise.Count(e => e.IdExercise == id) > 0;
        }
    }
}