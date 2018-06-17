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
using BaiTapAPI.Models;

namespace BaiTapAPI.Controllers
{
    public class DOCGIAController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/DOCGIA
        public IQueryable<DOCGIA> GetDOCGIAs()
        {
            return db.DOCGIAs;
        }

        // GET: api/DOCGIA/5
        [ResponseType(typeof(DOCGIA))]
        public IHttpActionResult GetDOCGIA(int id)
        {
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return NotFound();
            }

            return Ok(dOCGIA);
        }

        // PUT: api/DOCGIA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDOCGIA(int id, DOCGIA dOCGIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dOCGIA.MaDG)
            {
                return BadRequest();
            }

            db.Entry(dOCGIA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DOCGIAExists(id))
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

        // POST: api/DOCGIA
        [ResponseType(typeof(DOCGIA))]
        public IHttpActionResult PostDOCGIA(DOCGIA dOCGIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DOCGIAs.Add(dOCGIA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dOCGIA.MaDG }, dOCGIA);
        }

        // DELETE: api/DOCGIA/5
        [ResponseType(typeof(DOCGIA))]
        public IHttpActionResult DeleteDOCGIA(int id)
        {
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return NotFound();
            }

            db.DOCGIAs.Remove(dOCGIA);
            db.SaveChanges();

            return Ok(dOCGIA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DOCGIAExists(int id)
        {
            return db.DOCGIAs.Count(e => e.MaDG == id) > 0;
        }
    }
}