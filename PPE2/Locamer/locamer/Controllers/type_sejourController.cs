using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using locamer.Models;

namespace locamer.Controllers
{
    public class type_sejourController : Controller
    {
        private LOCAMERDataEntities db = new LOCAMERDataEntities();

        // GET: type_sejour
        public ActionResult Index()
        {
            return View(db.type_sejour.ToList());
        }

        // GET: type_sejour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_sejour type_sejour = db.type_sejour.Find(id);
            if (type_sejour == null)
            {
                return HttpNotFound();
            }
            return View(type_sejour);
        }

        // GET: type_sejour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: type_sejour/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "libelle,coef_reduc,id_typesejour")] type_sejour type_sejour)
        {
            if (ModelState.IsValid)
            {
                db.type_sejour.Add(type_sejour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_sejour);
        }

        // GET: type_sejour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_sejour type_sejour = db.type_sejour.Find(id);
            if (type_sejour == null)
            {
                return HttpNotFound();
            }
            return View(type_sejour);
        }

        // POST: type_sejour/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "libelle,coef_reduc,id_typesejour")] type_sejour type_sejour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_sejour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_sejour);
        }

        // GET: type_sejour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_sejour type_sejour = db.type_sejour.Find(id);
            if (type_sejour == null)
            {
                return HttpNotFound();
            }
            return View(type_sejour);
        }

        // POST: type_sejour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            type_sejour type_sejour = db.type_sejour.Find(id);
            db.type_sejour.Remove(type_sejour);
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
