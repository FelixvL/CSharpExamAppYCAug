using System;
using System.Collections.Generic;
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
    }
    
}