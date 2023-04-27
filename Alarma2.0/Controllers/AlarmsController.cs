using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alarma2._0.Models;

namespace Alarma2._0.Controllers
{
    public class AlarmsController : Controller
    {
        private AlarmEntities db = new AlarmEntities();

        // GET: Alarms
        public ActionResult Index()
        {
            return View(db.Alarms.ToList());
        }

        // GET: Alarms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarm alarm = db.Alarms.Find(id);
            if (alarm == null)
            {
                return HttpNotFound();
            }
            return View(alarm);
        }

        // GET: Alarms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alarms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlarma,NombreAlarma,Hora,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo")] Alarm alarm)
        {
            if (ModelState.IsValid)
            {
                db.Alarms.Add(alarm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alarm);
        }

        // GET: Alarms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarm alarm = db.Alarms.Find(id);
            if (alarm == null)
            {
                return HttpNotFound();
            }
            return View(alarm);
        }

        // POST: Alarms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlarma,NombreAlarma,Hora,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo")] Alarm alarm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alarm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alarm);
        }

        // GET: Alarms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarm alarm = db.Alarms.Find(id);
            if (alarm == null)
            {
                return HttpNotFound();
            }
            return View(alarm);
        }

        // POST: Alarms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alarm alarm = db.Alarms.Find(id);
            db.Alarms.Remove(alarm);
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
