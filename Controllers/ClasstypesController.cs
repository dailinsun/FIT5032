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
    public class ClasstypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Classtypes
        public ActionResult Index()
        {
            return View(db.Classtypes.ToList());
        }

        // GET: Classtypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classtype classtype = db.Classtypes.Find(id);
            if (classtype == null)
            {
                return HttpNotFound();
            }
            return View(classtype);
        }

        // GET: Classtypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classtypes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Color,Image,Teacher")] Classtype classtype)
        {
            if (ModelState.IsValid)
            {
                db.Classtypes.Add(classtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classtype);
        }

        // GET: Classtypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classtype classtype = db.Classtypes.Find(id);
            if (classtype == null)
            {
                return HttpNotFound();
            }
            return View(classtype);
        }

        // POST: Classtypes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Color,Image,Teacher")] Classtype classtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classtype);
        }

        // GET: Classtypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classtype classtype = db.Classtypes.Find(id);
            if (classtype == null)
            {
                return HttpNotFound();
            }
            return View(classtype);
        }

        // POST: Classtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classtype classtype = db.Classtypes.Find(id);
            db.Classtypes.Remove(classtype);
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
