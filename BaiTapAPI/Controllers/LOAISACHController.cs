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
    //ĐÂy là comment dạo
    public class LOAISACHController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/LOAISACH
        public IQueryable<LOAISACH> GetLOAISACHes()
        {
            return db.LOAISACHes;
        }

        // GET: api/LOAISACH/5
        [ResponseType(typeof(LOAISACH))]
        public IHttpActionResult GetLOAISACH(int id)
        {
            LOAISACH lOAISACH = db.LOAISACHes.Find(id);
            if (lOAISACH == null)
            {
                return NotFound();
            }

            return Ok(lOAISACH);
        }

        // PUT: api/LOAISACH/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLOAISACH(int id, LOAISACH lOAISACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lOAISACH.MaLoaiSach)
            {
                return BadRequest();
            }

            db.Entry(lOAISACH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LOAISACHExists(id))
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

        // POST: api/LOAISACH
        [ResponseType(typeof(LOAISACH))]
        public IHttpActionResult PostLOAISACH(LOAISACH lOAISACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LOAISACHes.Add(lOAISACH);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lOAISACH.MaLoaiSach }, lOAISACH);
        }

        // DELETE: api/LOAISACH/5
        [ResponseType(typeof(LOAISACH))]
        public IHttpActionResult DeleteLOAISACH(int id)
        {
            LOAISACH lOAISACH = db.LOAISACHes.Find(id);
            if (lOAISACH == null)
            {
                return NotFound();
            }

            db.LOAISACHes.Remove(lOAISACH);
            db.SaveChanges();

            return Ok(lOAISACH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LOAISACHExists(int id)
        {
            return db.LOAISACHes.Count(e => e.MaLoaiSach == id) > 0;
        }
    }
}