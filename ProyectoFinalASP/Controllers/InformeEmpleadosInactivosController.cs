using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalASP.Models;

namespace ProyectoFinalASP.Controllers
{
    public class InformeEmpleadosInactivosController : Controller
    {
        private ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformeEmpleadosInactivos
        public ActionResult VisualizarEmpleadosInactivos()
        {
            var result = from m in db.Empleados  where m.Estatus=="Inactivo" select m;
            return View(result.ToList());
        }
    }
}