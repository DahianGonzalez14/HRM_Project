using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalASP.Models;

namespace ProyectoFinalASP.Controllers
{
    public class InformeDepartamentosController : Controller
    {
        ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformeDepartamentos
        public ActionResult Departamentos()
        {
            var result = from m in db.Departamento  select m;
            return View(result.ToList());
        }
    }
}