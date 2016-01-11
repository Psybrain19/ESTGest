using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESTGest.Models;

namespace ESTGest.Controllers
{
    public class ChargeAccountReferencesController : Controller
    {
        private ESTGestDbEntities2 db = new ESTGestDbEntities2();

        // GET: ChargeAccountReferences
        public ActionResult Index()
        {
            return RedirectToAction("ReferenceList", "Admin");
        }

        // GET: ChargeAccountReferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeAccountReference chargeAccountReference = db.ChargeAccountReferences.Find(id);
            if (chargeAccountReference == null)
            {
                return HttpNotFound();
            }
            return View(chargeAccountReference);
        }
        
        // GET: ChargeAccountReferences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChargeAccountReferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "car_id,car_amount")] ChargeAccountReference chargeAccountReference)
        {
            Random rnd = new Random();
            int reference = rnd.Next(1, 999);
            while(reference.ToString().Length < 12)
            {
                reference = rnd.Next(1, 999);
            }           
            if (ModelState.IsValid)
            {
                chargeAccountReference.car_reference = reference.ToString();
                chargeAccountReference.car_valtime = DateTime.Now.AddDays(30.0);
                db.ChargeAccountReferences.Add(chargeAccountReference);
                db.SaveChanges();
                return RedirectToAction("ReferenceList", "Admin", chargeAccountReference);
            }

            return View(chargeAccountReference);
        }

        // GET: ChargeAccountReferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeAccountReference chargeAccountReference = db.ChargeAccountReferences.Find(id);
            if (chargeAccountReference == null)
            {
                return HttpNotFound();
            }
            return View(chargeAccountReference);
        }

        // POST: ChargeAccountReferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "car_id,car_reference,car_state,car_valtime,car_amount")] ChargeAccountReference chargeAccountReference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chargeAccountReference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ReferenceList", "Admin", chargeAccountReference);
            }
            return View(chargeAccountReference);
        }

        // GET: ChargeAccountReferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeAccountReference chargeAccountReference = db.ChargeAccountReferences.Find(id);
            if (chargeAccountReference == null)
            {
                return HttpNotFound();
            }
            return View(chargeAccountReference);
        }

        // POST: ChargeAccountReferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChargeAccountReference chargeAccountReference = db.ChargeAccountReferences.Find(id);
            db.ChargeAccountReferences.Remove(chargeAccountReference);
            db.SaveChanges();
            return RedirectToAction("ReferenceList", "Admin", chargeAccountReference);
        }

        
        [HttpGet]
        public ActionResult AskForNewReference()
        {
            return View();
        }
        /// <summary>
        /// Método que permite que o utilizador peça uma nova referência.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AskForNewReference([Bind(Include = "car_id,car_reference,car_state,car_valtime,car_amount")] ChargeAccountReference chargeAccountReference)
        {

            if (ModelState.IsValid)
            {
                chargeAccountReference.car_reference = "1445698";
                chargeAccountReference.car_state = 1;
                chargeAccountReference.car_valtime = DateTime.Now;
                db.ChargeAccountReferences.Add(chargeAccountReference);
                db.SaveChanges();
                return RedirectToAction("ChargeBankAccount", "BankAccounts");
            }

            return View(chargeAccountReference);

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
