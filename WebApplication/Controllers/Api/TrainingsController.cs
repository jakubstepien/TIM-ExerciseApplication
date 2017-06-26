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
using ApiClients.Models.DTO;
using WebApplication.Helpers;
using Database.Repositories.Statistic;

namespace WebApplication.Controllers.Api
{
    [RoutePrefix("api/trainings")]
    public class TrainingsController : ApiController
    {
        private ITrainingRepository trainingRepo;
        private IStatisticRepository statisticsRepo;

        public TrainingsController(ITrainingRepository trainingRepo, IStatisticRepository statisticRepo)
        {
            this.trainingRepo = trainingRepo;
            this.statisticsRepo = statisticRepo;
        }


        // GET: api/Trainings
        public IEnumerable<TrainingDTO> GetTrainings()
        {
            return trainingRepo.GetAll().ToArray().Select(s => s.ToDTO());
        }

        [Route("user/{userId}")]
        public IEnumerable<TrainingDTO> GetTrainingsForUser(Guid userId)
        {
            return trainingRepo.GetTrainingsForUser(userId).Select(s => s.ToDTO());
        }

        // GET: api/Trainings/5
        [ResponseType(typeof(Training))]
        public IHttpActionResult GetTraining(Guid id)
        {
            Training training = trainingRepo.GetById(id);
            if (training == null)
            {
                return NotFound();
            }

            return Ok(training.ToDTO());
        }

        //// PUT: api/Trainings/5
        //[Route("user/{userId}/")]
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTraining(Guid id, Training training)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != training.IdTraining)
        //    {
        //        return BadRequest();
        //    }

        //    db.Update(training);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TrainingExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Trainings
        [ResponseType(typeof(Training))]
        public IHttpActionResult PostTraining(TrainingDTO training)
        {
            var entity = training.ToEntity();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            trainingRepo.Add(entity);

            try
            {
                trainingRepo.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingExists(entity.IdTraining))
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

        [Route("finished/user/{userId}/")]
        public IHttpActionResult PostFinishedTraining(Guid userId, FinishedTrainingDTO finishedTraining)
        {
            foreach (var exercise in finishedTraining.Exercises)
            {
                statisticsRepo.Add(new Statistic
                {
                    Callories = exercise.Callories,
                    Date = exercise.Date,
                    ExerciseName = exercise.Name,
                    IdUser = exercise.UserId,
                    IdStatistic = Guid.NewGuid()
                });
            }
            statisticsRepo.SaveChanges();
            return Ok();
        }


        // DELETE: api/Trainings/5
        [ResponseType(typeof(Training))]
        public IHttpActionResult DeleteTraining(Guid id)
        {
            Training training = trainingRepo.GetById(id);
            if (training == null)
            {
                return NotFound();
            }

            trainingRepo.Remove(training);
            trainingRepo.SaveChanges();

            return Ok(training);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                trainingRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingExists(Guid id)
        {
            return trainingRepo.Exists(id);
        }
    }
}