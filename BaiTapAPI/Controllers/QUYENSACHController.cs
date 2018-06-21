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
    public class QUYENSACHController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/QUYENSACH
        public IQueryable<QUYENSACH> GetQUYENSACHes()
        {
            return db.QUYENSACHes;
        }

        // GET: api/QUYENSACH/5
        [ResponseType(typeof(QUYENSACH))]
        public IHttpActionResult GetQUYENSACH(int id)
        {
            QUYENSACH qUYENSACH = db.QUYENSACHes.Find(id);
            if (qUYENSACH == null)
            {
                return NotFound();
            }

            return Ok(qUYENSACH);
        }

        // PUT: api/QUYENSACH/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQUYENSACH(int id, QUYENSACH qUYENSACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qUYENSACH.MaSach)
            {
                return BadRequest();
            }

            db.Entry(qUYENSACH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QUYENSACHExists(id))
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

        // POST: api/QUYENSACH
        [ResponseType(typeof(QUYENSACH))]
        public IHttpActionResult PostQUYENSACH(QUYENSACH qUYENSACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QUYENSACHes.Add(qUYENSACH);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = qUYENSACH.MaSach }, qUYENSACH);
        }

        // DELETE: api/QUYENSACH/5
        [ResponseType(typeof(QUYENSACH))]
        public IHttpActionResult DeleteQUYENSACH(int id)
        {
            QUYENSACH qUYENSACH = db.QUYENSACHes.Find(id);
            if (qUYENSACH == null)
            {
                return NotFound();
            }

            db.QUYENSACHes.Remove(qUYENSACH);
            db.SaveChanges();

            return Ok(qUYENSACH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QUYENSACHExists(int id)
        {
            return db.QUYENSACHes.Count(e => e.MaSach == id) > 0;
        }
    }
}