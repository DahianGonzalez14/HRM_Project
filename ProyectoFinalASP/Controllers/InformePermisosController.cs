using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalASP.Models;

namespace ProyectoFinalASP.Controllers
{
    public class InformePermisosController : Controller
    {
        ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformePermisos
        public ActionResult Permisos(String buscar)
        {
            var query = from Permisos in db.Permisos
                        join Empleados in db.Empleados on Permisos.FK_Empleado equals Empleados.ID
                        where Empleados.Nombre == buscar
                        select Permisos;

                       
            //db.Nominas.Where(x => x.Mes == mes_ano || x.Año == mes_ano || buscar == null).ToList()
            return View(query.ToList());
        }
    }
}