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
    public class NHANVIENController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/NHANVIEN
        public IQueryable<NHANVIEN> GetNHANVIENs()
        {
            return db.NHANVIENs;
        }

        // GET: api/NHANVIEN/5
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult GetNHANVIEN(int id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            return Ok(nHANVIEN);
        }

        // PUT: api/NHANVIEN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNHANVIEN(int id, NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nHANVIEN.MaNV)
            {
                return BadRequest();
            }

            db.Entry(nHANVIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHANVIENExists(id))
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

        // POST: api/NHANVIEN
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult PostNHANVIEN(NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHANVIENs.Add(nHANVIEN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nHANVIEN.MaNV }, nHANVIEN);
        }

        // DELETE: api/NHANVIEN/5
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult DeleteNHANVIEN(int id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            db.NHANVIENs.Remove(nHANVIEN);
            db.SaveChanges();

            return Ok(nHANVIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHANVIENExists(int id)
        {
            return db.NHANVIENs.Count(e => e.MaNV == id) > 0;
        }
    }
}