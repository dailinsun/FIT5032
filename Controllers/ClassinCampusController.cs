using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChineseBridge.Models;

namespace ChineseBridge.Controllers
{
    public class ClassinCampusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassinCampus
        public ActionResult Index()
        {
            var classinCampuses = db.ClassinCampuses.Include(c => c.Campus).Include(c => c.Classtype);
            return View(classinCampuses.ToList());
        }

        // GET: ClassinCampus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassinCampus classinCampus = db.ClassinCampuses.Find(id);
            if (classinCampus == null)
            {
                return HttpNotFound();
            }
            return View(classinCampus);
        }

        // GET: ClassinCampus/Create
        public ActionResult Create()
        {
            ViewBag.CampusId = new SelectList(db.Campuses, "Id", "Name");
            ViewBag.ClasstypeId = new SelectList(db.Classtypes, "Id", "Name");
            return View();
        }

        // POST: ClassinCampus/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CampusId,ClasstypeId,StartTime")] ClassinCampus classinCampus)
        {
            if (ModelState.IsValid)
            {
                db.ClassinCampuses.Add(classinCampus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampusId = new SelectList(db.Campuses, "Id", "Name", classinCampus.CampusId);
            ViewBag.ClasstypeId = new SelectList(db.Classtypes, "Id", "Name", classinCampus.ClasstypeId);
            return View(classinCampus);
        }

        // GET: ClassinCampus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassinCampus classinCampus = db.ClassinCampuses.Find(id);
            if (classinCampus == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampusId = new SelectList(db.Campuses, "Id", "Name", classinCampus.CampusId);
            ViewBag.ClasstypeId = new SelectList(db.Classtypes, "Id", "Name", classinCampus.ClasstypeId);
            return View(classinCampus);
        }

        // POST: ClassinCampus/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CampusId,ClasstypeId,StartTime")] ClassinCampus classinCampus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classinCampus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampusId = new SelectList(db.Campuses, "Id", "Name", classinCampus.CampusId);
            ViewBag.ClasstypeId = new SelectList(db.Classtypes, "Id", "Name", classinCampus.ClasstypeId);
            return View(classinCampus);
        }

        // GET: ClassinCampus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassinCampus classinCampus = db.ClassinCampuses.Find(id);
            if (classinCampus == null)
            {
                return HttpNotFound();
            }
            return View(classinCampus);
        }

        // POST: ClassinCampus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassinCampus classinCampus = db.ClassinCampuses.Find(id);
            db.ClassinCampuses.Remove(classinCampus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
