using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        AFS_DB dt = new AFS_DB();

        AFS_DB rs = new AFS_DB();

        AFS_DB db = new AFS_DB();
        // GET: Homw
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact cot)
        {
            dt.Contacts.Add(cot);
            dt.SaveChanges();
            return RedirectToAction("Saved");
        }
        public ActionResult Saved()
        {
            return View();
        }

        public ActionResult PreReservation()
        {
            return View("PreReservation");
        }
        [HttpGet]
        public ActionResult Reservation()
        {
            return View("Reservation");
        }
        [HttpPost]
        public ActionResult Reservation(Reservation res)
        {
            rs.Reservations.Add(res);
            rs.SaveChanges();
            return RedirectToAction("Confirmed");
        }
        public ActionResult Confirmed()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User us)
        {
            var obj = db.Users.Where(x => x.UserName.Equals(us.UserName) && x.Password.Equals(us.Password)).FirstOrDefault();
            if (obj != null)
            {
                return RedirectToAction("Reservation");
            }
            else if (us.UserName == "admin" && us.Password == "admin")
            {
                return RedirectToAction("Admin");
            }
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

    }
}