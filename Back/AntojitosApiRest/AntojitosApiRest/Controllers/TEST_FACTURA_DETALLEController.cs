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
    public class TEST_FACTURA_DETALLEController : ApiController
    {
        private antojitosEntities db = new antojitosEntities();

        // GET: api/TEST_FACTURA_DETALLE
        public IQueryable<TEST_FACTURA_DETALLE> GetTEST_FACTURA_DETALLE()
        {
            return db.TEST_FACTURA_DETALLE;
        }

        // GET: api/TEST_FACTURA_DETALLE/5
        [ResponseType(typeof(TEST_FACTURA_DETALLE))]
        public IHttpActionResult GetTEST_FACTURA_DETALLE(decimal id)
        {
            TEST_FACTURA_DETALLE tEST_FACTURA_DETALLE = db.TEST_FACTURA_DETALLE.Find(id);
            if (tEST_FACTURA_DETALLE == null)
            {
                return NotFound();
            }

            return Ok(tEST_FACTURA_DETALLE);
        }

        // PUT: api/TEST_FACTURA_DETALLE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTEST_FACTURA_DETALLE(decimal id, TEST_FACTURA_DETALLE tEST_FACTURA_DETALLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tEST_FACTURA_DETALLE.IdFacturaDetalle)
            {
                return BadRequest();
            }

            db.Entry(tEST_FACTURA_DETALLE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TEST_FACTURA_DETALLEExists(id))
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

        // POST: api/TEST_FACTURA_DETALLE
        [ResponseType(typeof(TEST_FACTURA_DETALLE))]
        public IHttpActionResult PostTEST_FACTURA_DETALLE(TEST_FACTURA_DETALLE tEST_FACTURA_DETALLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TEST_FACTURA_DETALLE.Add(tEST_FACTURA_DETALLE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tEST_FACTURA_DETALLE.IdFacturaDetalle }, tEST_FACTURA_DETALLE);
        }

        // DELETE: api/TEST_FACTURA_DETALLE/5
        [ResponseType(typeof(TEST_FACTURA_DETALLE))]
        public IHttpActionResult DeleteTEST_FACTURA_DETALLE(decimal id)
        {
            TEST_FACTURA_DETALLE tEST_FACTURA_DETALLE = db.TEST_FACTURA_DETALLE.Find(id);
            if (tEST_FACTURA_DETALLE == null)
            {
                return NotFound();
            }

            db.TEST_FACTURA_DETALLE.Remove(tEST_FACTURA_DETALLE);
            db.SaveChanges();

            return Ok(tEST_FACTURA_DETALLE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TEST_FACTURA_DETALLEExists(decimal id)
        {
            return db.TEST_FACTURA_DETALLE.Count(e => e.IdFacturaDetalle == id) > 0;
        }
    }
}