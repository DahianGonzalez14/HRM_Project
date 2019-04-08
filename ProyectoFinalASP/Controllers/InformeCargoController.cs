using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalASP.Models;

namespace ProyectoFinalASP.Controllers
{
    public class InformeCargoController : Controller
    {
        ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformeCargo
        public ActionResult Cargos()
        {
            var result = from m in db.Cargo select m;
            return View(result.ToList());
        }
    }
}