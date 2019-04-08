using ProyectoFinalASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinalASP.Controllers
{
    public class InformeNominaController : Controller
    {
        private ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();
        // GET: InformeNomina
        public ActionResult BuscarNomina(String buscar)
        {
            int mes_ano = Convert.ToInt32(buscar);
            
            return View(db.Nominas.Where(x => x.Mes == mes_ano ||  x.Año == mes_ano || buscar==null).ToList());


        } 
       
    }
}