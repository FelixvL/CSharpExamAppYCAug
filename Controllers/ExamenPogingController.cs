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
            return View(examen);
        }
        public ActionResult ToonVraag(int vraagindex, int examenid)
        {
            testDTO td = new testDTO();
            td.huidigeIndex = vraagindex;
            td.examen = db.examens.Find(examenid);
            Console.WriteLine(td.examen.questions.Count + "<<<<<<") ;
            td.huidigeVraag = td.examen.questions[vraagindex];
            if (vraagindex > 0) {
                td.vorigeVraag = td.examen.questions[vraagindex - 1];
            }
            if (vraagindex < td.examen.questions.Count - 1) {
                td.volgendeVraag = td.examen.questions[vraagindex + 1];
            }
            ViewBag.tdtd = td;
            return View();
        }
    }
    public class testDTO {
        public Vraag huidigeVraag;
        public Vraag vorigeVraag;
        public Vraag volgendeVraag;
        public Examen examen;
        public int huidigeIndex;
    }
}