using ProyectoFinalASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinalASP.Controllers
{
    public class InformeEmpleadosActivosController : Controller
    
    {
        private ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformeEmpleadosActivos
        public ActionResult BuscarEmpleadosActivos(String buscar)
        {

            var query = from Empleados in db.Empleados where Empleados.Estatus=="Activo" select Empleados;
          
            if (!String.IsNullOrEmpty(buscar))
            {
                query = from Empleados in db.Empleados
                        join Departamento in db.Departamento on Empleados.Departamento equals Departamento.ID
                        where Empleados.Nombre == buscar || Departamento.Nombre == buscar && Empleados.Estatus == "Activo"
                        select Empleados;
                 
            }

            return View(query.ToList());
        }

    }
}