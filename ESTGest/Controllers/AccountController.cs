using ESTGest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ESTGest.Controllers
{
    public class AccountController : Controller
    {

        private ESTGestDbEntities2 db = new ESTGestDbEntities2();
        SQLMemberShipProvider sqlProvider = new SQLMemberShipProvider();


        /// <summary>
        /// Método que redireciona para a partialview login.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {

            return PartialView("~/Views/Account/PartialViews/_LoginPv.cshtml");
        }

        [Authorize]
        public ActionResult Protected()
        {
            var user = (UserIdentity)User.Identity;
            return View((object)user.UserId);
        }

        /// <summary>
        /// Método responsável pelo login e pela criação do cookie de sessão.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Models.User model, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                string name = (from u in db.Users
                               where u.u_number == model.u_number
                               select u.u_name).FirstOrDefault();

                if (sqlProvider.ValidateUser(name, model.u_password))
                {

                    FormsAuthentication.SetAuthCookie(name, false);

                    return RedirectToAction("Index", "Home", model.u_id);
                }
                else
                {
                    return RedirectToAction("ErrorLogin", "Home");
                }
            }
            return View(model);
        }

        /// <summary>
        /// Método responsável pelo logout do utilizador.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        // -- Snip --

            /// <summary>
            /// Método que cria a sessão de login e mete um tempo limite de 30 minutos.
            /// </summary>
            /// <param name="name">Utilizador</param>
            /// <param name="persistanceFlag"></param>
            /// <returns></returns>
        private User SetupFormsAuthTicket(string name, bool persistanceFlag)
        {
            User user;
            using (var usersContext = new Models.ESTGestDbEntities2())
            {
                user = sqlProvider.GetUser(name);
            }
            var userId = user.u_id;
            var userData = userId.ToString(CultureInfo.InvariantCulture);
            var authTicket = new FormsAuthenticationTicket(1, //version
                                name, // user name
                                DateTime.Now,             //creation
                                DateTime.Now.AddMinutes(30), //Expiration
                                persistanceFlag, //Persistent
                                userData);

            var encTicket = FormsAuthentication.Encrypt(authTicket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            return user;
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "username,user_password,user_password_confirm,user_address,user_birthday,user_phonenumber,user_city,user_state,user_homephonenumber,user_firstname,user_lastname,user_email")] User appUser)
        {
            // Provisório //////////////////
            //////////////////////////////
            ///////////////////////////////
            //Player player = new Player();
            //var model = (from p in db.Players
            //             select p).FirstOrDefault();
            //string[] names = { "Holi Nice", "Bali Rutew", "Poni Moli", "Tramp Timp" };
            //string[] position = { "Guarda-Redes", "Defesa", "Médio", "Avançado" };
            //float[] market_value = { 15.0f, 11.0f, .9f, .6f, 15.0f, 25.0f };
            //string[] nacionalidade = { "Brazil", "Portugal", "Espanha", "Holanda" };
            //string[] team = { "Sporting SCP", "SL Benfica", "SC Braga", "Porto FC" };

            //Random r = new Random();
            //if (model != null)
            //{
            //    for (int i = 0; i < 50; i++)
            //    {
            //        player = new Player()
            //        {
            //            player_name = names[r.Next(4)],
            //            player_position = position[r.Next(4)],
            //            player_market_value = market_value[r.Next(4)],
            //            player_nationality = nacionalidade[r.Next(4)],
            //            player_birthday = DateTime.Now,
            //            player_team = team[r.Next(4)],
            //        };
            //        db.Players.Add(player);
            //        db.SaveChanges();
            //    }
            //}

            if (ModelState.IsValid)
            {
                db.Users.Add(appUser);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(appUser);
        }

        /// <summary>
        /// Método que mostra o saldo total que o utilizador tem em carteira
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MyBudget()
        {

            var user = (from u in db.Users
                        where u.u_name == User.Identity.Name
                        select u).FirstOrDefault();

            var bankacc = (from b in db.BankAccounts
                           where b.ba_id == user.u_bankaccount_id
                           select b).FirstOrDefault();

            if(bankacc.bar_cash < 0)
            {
                bankacc.bar_cash = 0;
            }

            return PartialView("~/Views/Account/PartialViews/_MyBudget.cshtml", bankacc);
        }
    }
}
