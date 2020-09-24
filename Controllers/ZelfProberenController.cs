using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBExamenVragenAppDB;

namespace WebExamenVragenAppYCAug.Controllers
{
    public class ZelfProberenController : Controller
    {
        private DBExamContext db = new DBExamContext();

        // GET: Vraags
        public ActionResult Index()
        {
            ViewBag.Huppakee = db.vragen.ToList();
            return View(db.vragen.ToList());
        }


        public ActionResult CreeerVraag() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreeerVraag([Bind(Include = "VraagID,VraagTekst,Antwoord,Toelichting")] Vraag vraag) {
            db.vragen.Add(vraag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult WijzigVraag( int nummertje) {
            Vraag vraag = db.vragen.Find(nummertje);
            return View(vraag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WijzigVraag([Bind(Include = "VraagID,VraagTekst,Antwoord,Toelichting")] Vraag vraag) {
            db.Entry(vraag).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VerwijderVraag(int nummertje)
        {
            Vraag vraag = db.vragen.Find(nummertje);
            db.vragen.Remove(vraag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}