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
    public class mobil_homeController : Controller
    {
        private LOCAMERDataEntities db = new LOCAMERDataEntities();

        // GET: mobil_home
        public ActionResult Index()
        {
            var mobil_home = db.mobil_home.Include(m => m.tarif);
            return View(mobil_home.ToList());
        }

        // GET: mobil_home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mobil_home mobil_home = db.mobil_home.Find(id);
            if (mobil_home == null)
            {
                return HttpNotFound();
            }
            return View(mobil_home);
        }

        // GET: mobil_home/Create
        public ActionResult Create()
        {
            ViewBag.id_tarif = new SelectList(db.tarifs, "id_tarif", "libelle");
            return View();
        }

        // POST: mobil_home/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code_mobilhome,capacite,terrasse,id_tarif")] mobil_home mobil_home)
        {
            if (ModelState.IsValid)
            {
                db.mobil_home.Add(mobil_home);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tarif = new SelectList(db.tarifs, "id_tarif", "libelle", mobil_home.id_tarif);
            return View(mobil_home);
        }

        // GET: mobil_home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mobil_home mobil_home = db.mobil_home.Find(id);
            if (mobil_home == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tarif = new SelectList(db.tarifs, "id_tarif", "libelle", mobil_home.id_tarif);
            return View(mobil_home);
        }

        // POST: mobil_home/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code_mobilhome,capacite,terrasse,id_tarif")] mobil_home mobil_home)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobil_home).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tarif = new SelectList(db.tarifs, "id_tarif", "libelle", mobil_home.id_tarif);
            return View(mobil_home);
        }

        // GET: mobil_home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mobil_home mobil_home = db.mobil_home.Find(id);
            if (mobil_home == null)
            {
                return HttpNotFound();
            }
            return View(mobil_home);
        }

        // POST: mobil_home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mobil_home mobil_home = db.mobil_home.Find(id);
            db.mobil_home.Remove(mobil_home);
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
