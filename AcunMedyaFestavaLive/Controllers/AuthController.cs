using AcunMedyaFestavaLive.DataAccess;
using AcunMedyaFestavaLive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaFestavaLive.Controllers
{
    public class AuthController : Controller
    {
        Context context = new Context();

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            var claim = new UserOperationClaim { UserId = user.UserID, OperationClaimId = 1 };
            context.UserOperationClaims.Add(claim);
            context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            var user = context.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                UserDal userDal = new UserDal();
                var claims = userDal.GetClaims(user);
                var firstClaim = claims.FirstOrDefault();
                Session["UserId"] = user.UserID;
                Session["UserName"] = user.UserName;
                Session["ImageUrl"] = user.ImageUrl;
                Session["OperationClaimName"] = firstClaim?.ClaimName;
                if (firstClaim != null)
                {
                    if (firstClaim.OperationClaimID == 1)
                    {
                        return RedirectToAction("MyTicketList", "MyTicket", new { area = "Member" });
                    }
                    else if (firstClaim.OperationClaimID == 2)
                    {
                        return RedirectToAction("TicketList", "Ticket", new { area = "Admin" });
                    }
                }
            }

            ViewBag.UserName = Session["UserName"];
            ViewBag.UserId = Session["UserId"];
            ViewBag.ImageUrl = Session["ImageUrl"];
            ViewBag.OperationClaimName = Session["OperationClaimName"];
            return View();

        }

    }
}
