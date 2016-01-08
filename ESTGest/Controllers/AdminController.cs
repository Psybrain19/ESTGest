using ESTGest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ESTGest.Controllers
{
    public class AdminController : Controller
    {

        private ESTGestDbEntities2 db = new ESTGestDbEntities2();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult UsersList()
        //{
        //    return View(db.Users.ToList());
        //}

        //[HttpGet]
        //public ActionResult EditUser(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View("~/Views/Users/Edit.cshtml", user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////[Bind(Include = "p_id,p_designation,p_total,p_product_id")]
        //public ActionResult EditUser( User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(user);
        //}


        [HttpGet]
        public ActionResult ProductList()
        {
            return View(db.Products.ToList());
        }

        /// <summary>
        /// Método que permite ao administrador criar um produto
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult ProductCreate()
        {
            return RedirectToAction("Create", "Products");
        }

        /// <summary>
        /// Método que permite que administrador edite um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = db.Products.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Edit", "Products", new { id = p.pr_id });
        }

        /// <summary>
        /// Método que permite ao administrador ver os detalhes de um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = db.Products.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details", "Products", new { id = p.pr_id });
        }

        /// <summary>
        /// Método que permite que o administrador apague um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = db.Products.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Delete", "Products", new { id = p.pr_id });

        }

        [HttpGet]
        public ActionResult ReferenceList()
        {
            return View(db.ChargeAccountReferences.ToList());
        }

        /// <summary>
        /// Método que permite ao administrador criar uma referencia
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult ReferenceCreate()
        {
            return RedirectToAction("Create", "ChargeAccountReferences");
        }

        /// <summary>
        /// Método que permite que o administrador edite uma referência
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReferenceEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeAccountReference car = db.ChargeAccountReferences.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Edit", "ChargeAccountReferences", new { id = car.car_id });
        }


        /// <summary>
        /// Método que permite ao administrador ver os detalhes de uma referência
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReferenceDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeAccountReference car = db.ChargeAccountReferences.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details", "ChargeAccountReferences", new { id = car.car_id });
        }

        /// <summary>
        /// Método que permite que o administrador apague uma refêrencia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult ReferenceDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeAccountReference bank = db.ChargeAccountReferences.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Delete", "ChargeAccountReferences", new { id = bank.car_id });

        }


        /* CRUDS para Contas Bancárias*/

        [HttpGet]
        public ActionResult BankAccountList()
        {
            return View(db.BankAccounts.ToList());
        }

        /// <summary>
        /// Método que permite ao administrador criar uma conta bancária
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult BankAccountCreate()
        {
            return RedirectToAction("Create", "BankAccounts");
        }

        /// <summary>
        /// Método que permite ao administrador editar uma conta bancária
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BankAccountEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bank = db.BankAccounts.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Edit", "BankAccounts", new { id = bank.ba_id });
        }

        /// <summary>
        /// Método que permite ao administrador ver os detalhes da conta bancária
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BankAccountDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bank = db.BankAccounts.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details", "BankAccounts", new { id = bank.ba_id });
        }

        /// <summary>
        /// Método que permite que o administrador apague uma conta bancária
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BankAccountDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bank = db.BankAccounts.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Delete", "BankAccounts", new { id = bank.ba_id });

        }



        /* CRUDS para as COMPRAS*/

        [HttpGet]
        public ActionResult PurchaseList()
        {
            return View(db.Purchases.ToList());
        }

        /// <summary>
        /// Método que permite ao administrador criar uma compra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PurchaseCreate()
        {
            return RedirectToAction("Create", "Purchases");
        }

        /// <summary>
        /// Método que permite ao administrador editar uma compra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PurchaseEdit(int? id)
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
            return RedirectToAction("Edit", "Purchases", new { id = purchase.p_id });
        }

        /// <summary>
        /// Método que permite que o administrador veja os detalhes de uma compra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PurchaseDetails(int? id)
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
            return RedirectToAction("Details", "Purchases", new { id = purchase.p_id });
        }

        /// <summary>
        /// Método que permite ao utilizador apagar uma compra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PurchaseDelete(int? id)
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
            return RedirectToAction("Delete", "Purchases", new { id = purchase.p_id });

        }

    }
}