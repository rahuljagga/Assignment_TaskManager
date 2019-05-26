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
using TaskManagerTool;
using TaskManagerTool.Models;
using System.Web.Http.Cors;


namespace TaskManagerTool.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class TaskDBModelsController : ApiController
    {
        private TaskManagerDbContext db = new TaskManagerDbContext();

        // GET: api/TaskDBModels
        public IQueryable<Tasks> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/TaskDBModels/5
        [ResponseType(typeof(Tasks))]
        public IHttpActionResult GetTaskDBModel(int id)
        {
            Tasks taskDBModel = db.Tasks.Find(id);
            if (taskDBModel == null)
            {
                return NotFound();
            }

            return Ok(taskDBModel);
        }

        // PUT: api/TaskDBModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskDBModel(int id, Tasks taskDBModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskDBModel.TaskID)
            {
                return BadRequest();
            }

            db.Entry(taskDBModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskDBModelExists(id))
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

        // POST: api/TaskDBModels

        
        [ResponseType(typeof(Tasks))]
        public IHttpActionResult PostTaskDBModel(Tasks taskDBModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                     

            db.Tasks.Add(taskDBModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskDBModel.TaskID }, taskDBModel);
        }

        // DELETE: api/TaskDBModels/5
        [ResponseType(typeof(Tasks))]
        public IHttpActionResult DeleteTaskDBModel(int id)
        {
            Tasks taskDBModel = db.Tasks.Find(id);
            if (taskDBModel == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(taskDBModel);
            db.SaveChanges();

            return Ok(taskDBModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskDBModelExists(int id)
        {
            return db.Tasks.Count(e => e.TaskID == id) > 0;
        }
    }
}