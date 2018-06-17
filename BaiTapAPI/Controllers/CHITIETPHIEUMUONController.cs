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
    public class CHITIETPHIEUMUONController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/CHITIETPHIEUMUON
        public IQueryable<CHITIETPHIEUMUON> GetCHITIETPHIEUMUONs()
        {
            return db.CHITIETPHIEUMUONs;
        }

        // GET: api/CHITIETPHIEUMUON/5
        [ResponseType(typeof(CHITIETPHIEUMUON))]
        public IHttpActionResult GetCHITIETPHIEUMUON(int id)
        {
            CHITIETPHIEUMUON cHITIETPHIEUMUON = db.CHITIETPHIEUMUONs.Find(id);
            if (cHITIETPHIEUMUON == null)
            {
                return NotFound();
            }

            return Ok(cHITIETPHIEUMUON);
        }

        // PUT: api/CHITIETPHIEUMUON/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCHITIETPHIEUMUON(int id, CHITIETPHIEUMUON cHITIETPHIEUMUON)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cHITIETPHIEUMUON.SoPhieuMuon)
            {
                return BadRequest();
            }

            db.Entry(cHITIETPHIEUMUON).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CHITIETPHIEUMUONExists(id))
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

        // POST: api/CHITIETPHIEUMUON
        [ResponseType(typeof(CHITIETPHIEUMUON))]
        public IHttpActionResult PostCHITIETPHIEUMUON(CHITIETPHIEUMUON cHITIETPHIEUMUON)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CHITIETPHIEUMUONs.Add(cHITIETPHIEUMUON);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cHITIETPHIEUMUON.SoPhieuMuon }, cHITIETPHIEUMUON);
        }

        // DELETE: api/CHITIETPHIEUMUON/5
        [ResponseType(typeof(CHITIETPHIEUMUON))]
        public IHttpActionResult DeleteCHITIETPHIEUMUON(int id)
        {
            CHITIETPHIEUMUON cHITIETPHIEUMUON = db.CHITIETPHIEUMUONs.Find(id);
            if (cHITIETPHIEUMUON == null)
            {
                return NotFound();
            }

            db.CHITIETPHIEUMUONs.Remove(cHITIETPHIEUMUON);
            db.SaveChanges();

            return Ok(cHITIETPHIEUMUON);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CHITIETPHIEUMUONExists(int id)
        {
            return db.CHITIETPHIEUMUONs.Count(e => e.SoPhieuMuon == id) > 0;
        }
    }
}