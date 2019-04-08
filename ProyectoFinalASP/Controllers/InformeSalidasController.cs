using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalASP.Models;

namespace ProyectoFinalASP.Controllers
{
    public class InformeSalidasController : Controller
    {
        ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformeSalidas
        public ActionResult Salidas(String buscar)
        {
            var provider = from s in db.Salida select s;
            if (!String.IsNullOrEmpty(buscar))
            {
                int mes = Convert.ToInt32(buscar);
                //DateTime dt = DateTime.Parse(Mes);
                provider = provider.Where(j => j.FechaSalida.Value.Month == mes).Where(e => e.Empleados.Estatus == "Inactivo");
            }
            else
            {
                provider = provider.Where(e => e.Empleados.Estatus == "Inactivo");
            }
            return View(provider.ToList());
        }
    }
}