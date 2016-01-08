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
    public class BankAccountsController : Controller
    {
        private ESTGestDbEntities2 db = new ESTGestDbEntities2();

        // GET: BankAccounts
        public ActionResult Index()
        {
            return RedirectToAction("BankAccountList", "Admin");
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ba_id,ba_number,bar_cash")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(bankAccount);
                db.SaveChanges();
                return RedirectToAction("BankAccountList", "Admin", bankAccount);
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ba_id,ba_number,bar_cash")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BankAccountList", "Admin", bankAccount);
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankAccount bankAccount = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(bankAccount);
            db.SaveChanges();
            return RedirectToAction("BankAccountList", "Admin", bankAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult ChargeBankAccount()
        {
            return View(db.ChargeAccountReferences.ToList());
        }


        [HttpPost]
        public ActionResult ChargeBankAccount(List<int> RefIds)
        {
            var user_bid = (from u in db.Users
                            where u.u_name == User.Identity.Name
                            select u.u_bankaccount_id).FirstOrDefault();
            var bancc = (from b in db.BankAccounts
                         where b.ba_id == user_bid
                         select b).FirstOrDefault();

            foreach (int rids in RefIds)
            {
                bancc.bar_cash = bancc.bar_cash + (from refid in db.ChargeAccountReferences
                                  where refid.car_id == rids
                                  select refid.car_amount).FirstOrDefault();
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
