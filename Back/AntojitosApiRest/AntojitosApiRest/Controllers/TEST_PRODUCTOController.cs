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
    public class TEST_PRODUCTOController : ApiController
    {
        private antojitosEntities db = new antojitosEntities();

        // GET: api/TEST_PRODUCTO
        public IQueryable<TEST_PRODUCTO> GetTEST_PRODUCTO()
        {
            return db.TEST_PRODUCTO;
        }

        // GET: api/TEST_PRODUCTO/5
        [ResponseType(typeof(TEST_PRODUCTO))]
        public IHttpActionResult GetTEST_PRODUCTO(decimal id)
        {           
            TEST_PRODUCTO tEST_PRODUCTO = db.TEST_PRODUCTO.Find(id);
            if (tEST_PRODUCTO == null)
            {
                return NotFound();
            }

            return Ok(tEST_PRODUCTO);
        }

        // PUT: api/TEST_PRODUCTO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTEST_PRODUCTO(decimal id, TEST_PRODUCTO tEST_PRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tEST_PRODUCTO.IdProducto)
            {
                return BadRequest();
            }

            db.Entry(tEST_PRODUCTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TEST_PRODUCTOExists(id))
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

        // POST: api/TEST_PRODUCTO
        [ResponseType(typeof(TEST_PRODUCTO))]
        public IHttpActionResult PostTEST_PRODUCTO(TEST_PRODUCTO tEST_PRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TEST_PRODUCTO.Add(tEST_PRODUCTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tEST_PRODUCTO.IdProducto }, tEST_PRODUCTO);
        }

        // DELETE: api/TEST_PRODUCTO/5
        [ResponseType(typeof(TEST_PRODUCTO))]
        public IHttpActionResult DeleteTEST_PRODUCTO(decimal id)
        {
            TEST_PRODUCTO tEST_PRODUCTO = db.TEST_PRODUCTO.Find(id);
            if (tEST_PRODUCTO == null)
            {
                return NotFound();
            }

            db.TEST_PRODUCTO.Remove(tEST_PRODUCTO);
            db.SaveChanges();

            return Ok(tEST_PRODUCTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TEST_PRODUCTOExists(decimal id)
        {
            return db.TEST_PRODUCTO.Count(e => e.IdProducto == id) > 0;
        }
    }
}