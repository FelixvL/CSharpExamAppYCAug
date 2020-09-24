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
            return View(db.vragen.ToList());
        }
    }
}