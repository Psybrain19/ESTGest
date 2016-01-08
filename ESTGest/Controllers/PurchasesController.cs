using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESTGest.Models;
using ESTGest.ViewModel;

namespace ESTGest.Controllers
{
    public class PurchasesController : Controller
    {
        private ESTGestDbEntities2 db = new ESTGestDbEntities2();


        // GET: Purchases
        public ActionResult Index()
        {
            var user = (from u in db.Users
                        where u.u_name == User.Identity.Name
                        select u).FirstOrDefault();

            var upl = (from purchasel in db.UserPurchaseLists
                       where purchasel.upl_user_id == user.u_id
                       select purchasel.upl_purchase_id).ToList();

            List<Purchase> purchaseList = new List<Purchase>();

            foreach (int pid in upl)
            {
                purchaseList.Add((from p in db.Purchases
                                  where p.p_id == pid
                                  select p).FirstOrDefault());
            }


            return View(purchaseList);
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Método que permite fazer uma compra
        /// </summary>
        /// <param name="purchase"></param>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_id,p_designation,p_total,p_product_id")] Purchase purchase, List<int> ProductIds)
        {

            var user = (from u in db.Users
                        where u.u_name == User.Identity.Name
                        select u).FirstOrDefault();

            var bankacc = (from b in db.BankAccounts
                           where b.ba_id == user.u_bankaccount_id
                           select b).FirstOrDefault();

            double total = 0.0;

            if (ModelState.IsValid)
            {

                foreach (int p in ProductIds)
                {
                    total += (from prod in db.Products
                              where prod.pr_id == p
                              select prod.pr_price).FirstOrDefault();
                }

                if ((bankacc.bar_cash - total) >= 0)
                {
                    purchase.p_total = total;
                    bankacc.bar_cash = bankacc.bar_cash - total;
                    //db.BankAccounts.Add(bankacc);
                    db.Purchases.Add(purchase);
                    PurchaseProductList ppl = new PurchaseProductList();
                    foreach (int pid in ProductIds)
                    {
                        ppl = new PurchaseProductList
                        {
                            ppl_product_id = pid,
                            ppl_purchase_id = purchase.p_id,
                        };
                        db.PurchaseProductLists.Add(ppl);

                    }
                    UserPurchaseList upl = new UserPurchaseList
                    {
                        upl_purchase_id = purchase.p_id,
                        upl_user_id = user.u_id
                    };
                    db.UserPurchaseLists.Add(upl);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("~/Views/Purchases/Error.cshtml");
                }
            }

            return View(purchase);
        }

        /// <summary>
        /// Método que retorna uma lista de produtos associado á compra.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductList(int? id)
        {
            var model = (from p in db.Products
                         select p).ToList();

            var ppl = (from pl in db.PurchaseProductLists
                       where pl.ppl_purchase_id == id
                       select pl.ppl_product_id).ToList();
            List<Product> pdl = new List<Product>();
            foreach (int ids in ppl)
            {
                pdl.Add((from p in db.Products
                         where p.pr_id == ids
                         select p).FirstOrDefault());
            }

            return PartialView("~/Views/Purchases/PartialViews/_ProductList.cshtml", pdl);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_id,p_designation,p_total,p_product_id")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();

            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("PurchaseList", "Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Purchase purchase = db.Purchases.Find(id);
            //db.Purchases.Remove(purchase);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            Purchase purchase = db.Purchases.Find(id);

            var ppl = (from p in db.PurchaseProductLists
                       where p.ppl_purchase_id == id
                       select p).ToList();

            foreach (PurchaseProductList pr in ppl)
            {
                db.PurchaseProductLists.Remove(pr);
            }

            var user = (from u in db.Users
                        where u.u_name == User.Identity.Name
                        select u).FirstOrDefault();

            var upl = (from up in db.UserPurchaseLists
                       where up.upl_purchase_id == purchase.p_id
                       select up).ToList();

            foreach (UserPurchaseList upList in upl)
            {
                db.UserPurchaseLists.Remove(upList);
            }

            db.Purchases.Remove(purchase);
            db.SaveChanges();

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("PurchaseList", "Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método que retorna uma lista de produtos disponíveis.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult ProductDropDownList()
        {

            var model = (from p in db.Products
                         select p).ToList();

            return PartialView("~/Views/Purchases/PartialViews/_DropDownProductList.cshtml", model);
        }

        /// <summary>
        /// Método que retorna o valor total de uma compra.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PurchasesTotalAmount()
        {
            double total = 0;
            PurchaseTotal pt;
            var user_p = (from u in db.Users
                          where u.u_name == User.Identity.Name
                          select u.u_id).FirstOrDefault();

            var upl = (from up in db.UserPurchaseLists
                       where up.upl_user_id == user_p
                       select up.upl_purchase_id).ToList();


            foreach (int pid in upl)
            {
                total = total + (double)(from p in db.Purchases
                                         where p.p_id == pid
                                         select p.p_total).FirstOrDefault();
            }
            pt = new PurchaseTotal
            {
                Total = total,
            };

            return PartialView("~/Views/Purchases/PartialViews/_Total.cshtml", pt);
        }

        [HttpGet]
        public ActionResult IndexAdmin()
        {
            return RedirectToAction("PurchaseList", "Admin");
        }

    }
}
