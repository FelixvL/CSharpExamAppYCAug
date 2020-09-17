using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBExamenVragenAppDB;

namespace WebExamenVragenAppYCAug.Controllers
{
    public class VraagsController : Controller
    {
        private DBExamContext db = new DBExamContext();

        // GET: Vraags
        public ActionResult Index()
        {
            return View(db.vragen.ToList());
        }

        // GET: Vraags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vraag vraag = db.vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // GET: Vraags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vraags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VraagID,VraagTekst,Antwoord,Toelichting")] Vraag vraag)
        {
            if (ModelState.IsValid)
            {
                db.vragen.Add(vraag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vraag);
        }

        // GET: Vraags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vraag vraag = db.vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // POST: Vraags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VraagID,VraagTekst,Antwoord,Toelichting")] Vraag vraag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vraag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vraag);
        }

        // GET: Vraags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vraag vraag = db.vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // POST: Vraags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vraag vraag = db.vragen.Find(id);
            db.vragen.Remove(vraag);
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
