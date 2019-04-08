using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalASP.Models;

namespace ProyectoFinalASP.Controllers
{
    public class InformeEntradasController : Controller
    {
        ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformeEntradas
        public ActionResult Entradas(String buscar)
        {
            int mes = Convert.ToInt32(buscar);
            var query = from Empleados in db.Empleados
                        where Empleados.Fecha_DE_Ingreso.Value.Month == mes
                        select Empleados;
          
        
            return View(query.ToList());
        }
    }
}