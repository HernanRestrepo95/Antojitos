using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AntojitosApiRest.Models;

namespace AntojitosApiRest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TEST_CLIENTEController : ApiController
    {
        private antojitosEntities db = new antojitosEntities();

        // GET: api/TEST_CLIENTE
        public IQueryable<TEST_CLIENTE> GetTEST_CLIENTE()
        {
            return db.TEST_CLIENTE;
        }

        // GET: api/TEST_CLIENTE/5
        [ResponseType(typeof(TEST_CLIENTE))]
        public IHttpActionResult GetTEST_CLIENTE(decimal id)
        {
            TEST_CLIENTE tEST_CLIENTE = (from b in db.TEST_CLIENTE
                                        where b.Identifiacion.Equals(id)
                                        select b).SingleOrDefault();
            if (tEST_CLIENTE == null)
            {
                return NotFound();
            }

            return Ok(tEST_CLIENTE);
        }

        // PUT: api/TEST_CLIENTE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTEST_CLIENTE(decimal id, TEST_CLIENTE tEST_CLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tEST_CLIENTE.IdCliente)
            {
                return BadRequest();
            }

            db.Entry(tEST_CLIENTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TEST_CLIENTEExists(id))
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

        // POST: api/TEST_CLIENTE
        [ResponseType(typeof(TEST_CLIENTE))]
        public IHttpActionResult PostTEST_CLIENTE(TEST_CLIENTE tEST_CLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TEST_CLIENTE.Add(tEST_CLIENTE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tEST_CLIENTE.IdCliente }, tEST_CLIENTE);
        }

        // DELETE: api/TEST_CLIENTE/5
        [ResponseType(typeof(TEST_CLIENTE))]
        public IHttpActionResult DeleteTEST_CLIENTE(decimal id)
        {
            TEST_CLIENTE tEST_CLIENTE = db.TEST_CLIENTE.Find(id);
            if (tEST_CLIENTE == null)
            {
                return NotFound();
            }

            db.TEST_CLIENTE.Remove(tEST_CLIENTE);
            db.SaveChanges();

            return Ok(tEST_CLIENTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TEST_CLIENTEExists(decimal id)
        {
            return db.TEST_CLIENTE.Count(e => e.IdCliente == id) > 0;
        }
    }
}