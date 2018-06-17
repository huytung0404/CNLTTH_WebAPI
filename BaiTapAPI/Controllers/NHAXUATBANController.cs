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
    public class NHAXUATBANController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/NHAXUATBAN
        public IQueryable<NHAXUATBAN> GetNHAXUATBANs()
        {
            return db.NHAXUATBANs;
        }

        // GET: api/NHAXUATBAN/5
        [ResponseType(typeof(NHAXUATBAN))]
        public IHttpActionResult GetNHAXUATBAN(int id)
        {
            NHAXUATBAN nHAXUATBAN = db.NHAXUATBANs.Find(id);
            if (nHAXUATBAN == null)
            {
                return NotFound();
            }

            return Ok(nHAXUATBAN);
        }

        // PUT: api/NHAXUATBAN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNHAXUATBAN(int id, NHAXUATBAN nHAXUATBAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nHAXUATBAN.MaNXB)
            {
                return BadRequest();
            }

            db.Entry(nHAXUATBAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHAXUATBANExists(id))
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

        // POST: api/NHAXUATBAN
        [ResponseType(typeof(NHAXUATBAN))]
        public IHttpActionResult PostNHAXUATBAN(NHAXUATBAN nHAXUATBAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHAXUATBANs.Add(nHAXUATBAN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nHAXUATBAN.MaNXB }, nHAXUATBAN);
        }

        // DELETE: api/NHAXUATBAN/5
        [ResponseType(typeof(NHAXUATBAN))]
        public IHttpActionResult DeleteNHAXUATBAN(int id)
        {
            NHAXUATBAN nHAXUATBAN = db.NHAXUATBANs.Find(id);
            if (nHAXUATBAN == null)
            {
                return NotFound();
            }

            db.NHAXUATBANs.Remove(nHAXUATBAN);
            db.SaveChanges();

            return Ok(nHAXUATBAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHAXUATBANExists(int id)
        {
            return db.NHAXUATBANs.Count(e => e.MaNXB == id) > 0;
        }
    }
}