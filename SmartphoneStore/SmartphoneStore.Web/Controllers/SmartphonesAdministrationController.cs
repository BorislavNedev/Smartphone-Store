using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartphoneStore.Data;
using SmartphoneStore.Models;

namespace SmartphoneStore.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SmartphonesAdministrationController : Controller
    {
        private SmartphoneStoreDbContext db = new SmartphoneStoreDbContext();

        // GET: SmartphonesAdministration
        public ActionResult Index()
        {
            var smartphones = db.Smartphones.Include(s => s.Manufacturer);
            return View(smartphones.ToList());
        }

        // GET: SmartphonesAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // GET: SmartphonesAdministration/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: SmartphonesAdministration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,MonitorSize,RamMemorySize,ImageUrl,Price,Description,ManufacturerId")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Smartphones.Add(smartphone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", smartphone.ManufacturerId);
            return View(smartphone);
        }

        // GET: SmartphonesAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", smartphone.ManufacturerId);
            return View(smartphone);
        }

        // POST: SmartphonesAdministration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,MonitorSize,RamMemorySize,ImageUrl,Price,Description,ManufacturerId")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smartphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", smartphone.ManufacturerId);
            return View(smartphone);
        }

        // GET: SmartphonesAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // POST: SmartphonesAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smartphone smartphone = db.Smartphones.Find(id);
            db.Smartphones.Remove(smartphone);
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
