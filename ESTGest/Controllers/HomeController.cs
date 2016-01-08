using ESTGest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESTGest.Controllers
{
    public class HomeController : Controller
    {
        private ESTGestDbEntities2 db = new ESTGestDbEntities2();

        public ActionResult ErrorLogin()
        {
            return View();
        }

        public ActionResult Index()
        {

            /* DATABASE FILL */

            //ChargeAccountReference reff = new ChargeAccountReference
            //{
            //    car_amount = 10,
            //    car_reference = "11253456",
            //    car_state = 0,
            //    car_valtime = DateTime.Now,
            //};
            //ChargeAccountReference reff1 = new ChargeAccountReference
            //{
            //    car_amount = 20,
            //    car_reference = "11253456",
            //    car_state = 0,
            //    car_valtime = DateTime.Now,
            //};
            //ChargeAccountReference reff2 = new ChargeAccountReference
            //{
            //    car_amount = 50,
            //    car_reference = "11253456",
            //    car_state = 0,
            //    car_valtime = DateTime.Now,
            //};
            //db.ChargeAccountReferences.Add(reff1);
            //db.ChargeAccountReferences.Add(reff2);
            //db.SaveChanges();
            //Product p = new Product
            //{
            //    pr_designation = "Café",
            //    pr_price = 0.6,
            //};

            //Product p1 = new Product
            //{
            //    pr_designation = "Pastel de Nada",
            //    pr_price = 0.5,
            //};

            //Product p2 = new Product
            //{
            //    pr_designation = "Baguete de Frango",
            //    pr_price = 1.45,
            //};

            //Product p3 = new Product
            //{
            //    pr_designation = "Batata Frita Lays",
            //    pr_price = 1,
            //};

            //db.Products.Add(p);
            //db.Products.Add(p1);
            //db.Products.Add(p2);
            //db.Products.Add(p3);
            //db.SaveChanges();
            //CourseCategory cc = new CourseCategory
            //{
            //    cc_designation = "Licenciatura",
            //};
            //db.CourseCategory.Add(cc);
            //db.SaveChanges();
            //Course course = new Course
            //{
            //    c_coursecat_id = cc.cc_id,
            //    c_designation = "Informática",
            //};
            //db.Course.Add(course);
            //db.SaveChanges();

            //Schedule sch = new Schedule
            //{
            //    sch_designation = "Horario1",
            //};
            //db.Schedule.Add(sch);

            //CourseClass courseClass = new CourseClass
            //{
            //    cc_designation = "Turma1",
            //    cc_course_id = course.c_id,
            //    cc_schedule_id = sch.sch_id,
            //};
            //db.CourseClass.Add(courseClass);

            //BankAccount bacc = new BankAccount
            //{
            //    ba_number = "14444",
            //    bar_cash = 0,

            //};
            //db.BankAccount.Add(bacc);

            //ChargeAccountReference chargAcc = new ChargeAccountReference
            //{
            //    car_amount = 5,
            //    car_reference = "123456789",
            //    car_state = 0,
            //    car_valtime = DateTime.Now,

            //};

            //db.ChargeAccountReference.Add(chargAcc);

            //User user = new User
            //{
            //    u_name = "Bruno Leonardo",
            //    u_number = 120221050,
            //    u_password = "120221050",
            //    u_course_id = 1,
            //    u_courseclass_id = 1,
            //    u_bankaccount_id = 3,
            //    u_chargeaccref_id = 3,


            //};
            //db.User.Add(user);

            //Roles role = new Roles
            //{
            //    RoleName = "Aluno",
            //    RoleDescription = "Role para o ALuno",

            //};

            //db.Roles.Add(role);

            //UserRoles ur = new UserRoles
            //{
            //    UserId = user.u_id,
            //    UserRole = role.RoleId,
            //};

            //db.UserRoles.Add(ur);

            //ScheduleContent sccc = new ScheduleContent
            //{
            //       scontent_sch_id = sch.sch_id,
            //};

            //db.ScheduleContent.Add(sccc);

            //Discipline d1 = new Discipline
            //{
            //    d_course_id = course.c_id,
            //    d_designation = "Engenharia de Software",
            //    d_credits = 6,
            //    d_yearcourse = 3,
            //    d_value = 0,
            //    d_user_id = 1,
            //    d_scontent_id = sccc.scontent_id,
            //};
            //Discipline d2 = new Discipline
            //{
            //    d_course_id = course.c_id,
            //    d_designation = "Programação Visual",
            //    d_credits = 6,
            //    d_yearcourse = 3,
            //    d_value = 0,
            //    d_user_id = 1,
            //    d_scontent_id = sccc.scontent_id,
            //};
            //db.Discipline.Add(d1);
            //db.Discipline.Add(d2);

            //db.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}