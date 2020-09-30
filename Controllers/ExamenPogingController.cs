using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBExamenVragenAppDB;

namespace WebExamenVragenAppYCAug.Controllers
{
    public class ExamenPogingController : Controller
    {
        private DBExamContext db = new DBExamContext();

        // GET: ExamenPoging
        public ActionResult Index()
        {
            ViewBag.Vragenlijst = db.vragen.ToList();
            ViewBag.Examenlijst = db.examens.ToList();
            

            return View(db.vragen.ToList());
        }
        public ActionResult StartExamen(int examennummer) {
            Examen examen = db.examens.Find(examennummer);
            ViewBag.pogingen = db.pogingen;
            ViewBag.antwoorden = db.antwoorden;
            return View(examen);
        }
        public ActionResult StartPoging(int examenid)
        {
            Examen examen = db.examens.Find(examenid);
            Poging p = new Poging();
            p.Examen = examen;
            db.pogingen.Add(p);
            db.SaveChanges();
            ViewBag.pogingen = db.pogingen;
            ViewBag.antwoorden = db.antwoorden;
            return View("StartExamen",examen);
        }
        public ActionResult ToonVraag(int vraagindex, int pogingid)
        {
            testDTO td = new testDTO();
            td.antwoord = new Antwoord();
            td.huidigeIndex = vraagindex;
            Poging poging = db.pogingen.Find(pogingid);
            td.poging = poging;
            td.examen = db.examens.Find(poging.Examen.ExamenId);
            Console.WriteLine(td.examen.questions.Count + "<<<<<<") ;
            td.huidigeVraag = td.examen.questions[vraagindex];
            if (vraagindex > 0) {
                td.vorigeVraag = td.examen.questions[vraagindex - 1];
            }
            if (vraagindex < td.examen.questions.Count - 1) {
                td.volgendeVraag = td.examen.questions[vraagindex + 1];
            }
            ViewBag.tdtd = td;
            return View(td);
        }
        [HttpPost]
        public String Hoi(string antwoord, int pogingid, int vraagid)
        {
            Antwoord mijnAntwoord = new Antwoord();
            mijnAntwoord.AntwoordTekst = antwoord;
            mijnAntwoord.Vraag = db.vragen.Find(vraagid);
            mijnAntwoord.Poging = db.pogingen.Find(pogingid);
            db.antwoorden.Add(mijnAntwoord);
            db.SaveChanges();
            return "is het deze" + antwoord + pogingid + vraagid;
        }
    }
    public class testDTO {
        public Vraag huidigeVraag;
        public Vraag vorigeVraag;
        public Vraag volgendeVraag;
        public Examen examen;
        public Poging poging;
        public Antwoord antwoord;
        public int huidigeIndex;
    }
}