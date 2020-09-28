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
            ViewBag.Examens = db.examens.ToList();
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

        public ActionResult CreeerExamen()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreeerExamen([Bind(Include = "naam")] Examen examen)
        {
            db.examens.Add(examen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult WijzigVraag( int nummertje) {
            Vraag vraag = db.vragen.Find(nummertje);
            return View(vraag);
        }
        public ActionResult ManageExamen(int nummertje)
        {
            Examen examen = db.examens.Find(nummertje);
            ViewBag.vragen = db.vragen.ToList();
            return View(examen);
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
        public ActionResult VoegVraagToe(int examenid, int vraagid)
        {
            Vraag vraag = db.vragen.Find(vraagid);
            Examen examen = db.examens.Find(examenid);
            examen.questions.Add(vraag);
            db.SaveChanges();
            return RedirectToAction("ManageExamen", new { nummertje = examen.ExamenId});
        }
        public ActionResult VerwijderVraagExamen(int examenid, int vraagid)
        {
            Vraag vraag = db.vragen.Find(vraagid);
            Examen examen = db.examens.Find(examenid);
            examen.questions.Remove(vraag);
            db.SaveChanges();
            return RedirectToAction("ManageExamen", new { nummertje = examen.ExamenId });
        }
    }

}