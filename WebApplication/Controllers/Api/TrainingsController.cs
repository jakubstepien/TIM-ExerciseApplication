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
    public class TrainingsController : ApiController
    {
        private ITrainingRepository db;

        public TrainingsController(ITrainingRepository db)
        {
            this.db = db;
        }

        // GET: api/Trainings
        public IQueryable<Training> GetTrainings()
        {
            return db.GetAll();
        }

        // GET: api/Trainings/5
        [ResponseType(typeof(Training))]
        public IHttpActionResult GetTraining(Guid id)
        {
            Training training = db.GetById(id);
            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        // PUT: api/Trainings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTraining(Guid id, Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != training.IdTraining)
            {
                return BadRequest();
            }

            db.Update(training);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
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

        // POST: api/Trainings
        [ResponseType(typeof(Training))]
        public IHttpActionResult PostTraining(Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(training);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingExists(training.IdTraining))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = training.IdTraining }, training);
        }

        // DELETE: api/Trainings/5
        [ResponseType(typeof(Training))]
        public IHttpActionResult DeleteTraining(Guid id)
        {
            Training training = db.GetById(id);
            if (training == null)
            {
                return NotFound();
            }

            db.Remove(training);
            db.SaveChanges();

            return Ok(training);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingExists(Guid id)
        {
            return db.Exists(id);
        }
    }
}