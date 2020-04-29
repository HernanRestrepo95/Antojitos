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
    public class TEST_FACTURAController : ApiController
    {
        private antojitosEntities db = new antojitosEntities();

        // GET: api/TEST_FACTURA
        public IQueryable<TEST_FACTURA> GetTEST_FACTURA()
        {
            return db.TEST_FACTURA;
        }

        // GET: api/TEST_FACTURA/5
        [ResponseType(typeof(TEST_FACTURA))]
        public IHttpActionResult GetTEST_FACTURA(decimal id)
        {
            TEST_FACTURA tEST_FACTURA = db.TEST_FACTURA.Find(id);
            if (tEST_FACTURA == null)
            {
                return NotFound();
            }

            return Ok(tEST_FACTURA);
        }

        // PUT: api/TEST_FACTURA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTEST_FACTURA(decimal id, TEST_FACTURA tEST_FACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tEST_FACTURA.IdFactura)
            {
                return BadRequest();
            }

            db.Entry(tEST_FACTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TEST_FACTURAExists(id))
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

        // POST: api/TEST_FACTURA
        [ResponseType(typeof(TEST_FACTURA))]
        public IHttpActionResult PostTEST_FACTURA(TEST_FACTURA tEST_FACTURA)
        {

            tEST_FACTURA.FechaVenta = DateTime.Now;

            foreach (var detalles in tEST_FACTURA.TEST_FACTURA_DETALLE)
            {
                TEST_PRODUCTO tEST_PRODUCTO = db.TEST_PRODUCTO.Find(detalles.IdProducto);
                tEST_PRODUCTO.Stock = tEST_PRODUCTO.Stock - detalles.Cantidad;

                db.Entry(tEST_PRODUCTO).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            db.TEST_FACTURA.Add(tEST_FACTURA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tEST_FACTURA.IdFactura }, tEST_FACTURA);
        }

        // DELETE: api/TEST_FACTURA/5
        [ResponseType(typeof(TEST_FACTURA))]
        public IHttpActionResult DeleteTEST_FACTURA(decimal id)
        {
            TEST_FACTURA tEST_FACTURA = db.TEST_FACTURA.Find(id);
            if (tEST_FACTURA == null)
            {
                return NotFound();
            }

            db.TEST_FACTURA.Remove(tEST_FACTURA);
            db.SaveChanges();

            return Ok(tEST_FACTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TEST_FACTURAExists(decimal id)
        {
            return db.TEST_FACTURA.Count(e => e.IdFactura == id) > 0;
        }
    }
}