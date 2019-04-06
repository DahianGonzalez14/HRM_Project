using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalASP.Models;

namespace ProyectoFinalASP.Controllers
{
    public class NominasController : Controller
    {
        private ProyectoFinalAspEntities db = new ProyectoFinalAspEntities();

        // GET: Nominas
        public ActionResult Index()
        {
            var nominas = db.Nominas.Include(n => n.Empleados);
            return View(nominas.ToList());
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Nominas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MontoTotal,Mes,Año")] Nominas nominas)
        {
            Nullable<Decimal> total = (from result in db.Empleados where result.Estatus=="Activo" select result.Salario).Sum();
            if (ModelState.IsValid)
            {
                db.Nominas.Add(nominas);
                nominas.MontoTotal = total;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Empleado = new SelectList(db.Empleados, "ID", "Nombre", nominas.FK_Empleado);
            return View(nominas);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Empleado = new SelectList(db.Empleados, "ID", "Nombre", nominas.FK_Empleado);
            return View(nominas);
        }

        // POST: Nominas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MontoTotal,FK_Empleado,Mes,Año")] Nominas nominas)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(nominas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Empleado = new SelectList(db.Empleados, "ID", "Nombre", nominas.FK_Empleado);
            return View(nominas);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nominas nominas = db.Nominas.Find(id);
            db.Nominas.Remove(nominas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
