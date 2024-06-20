using AcunMedyaFestavaLive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaFestavaLive.Areas.Member.Models;

namespace AcunMedyaFestavaLive.Areas.Member.Controllers
{
    [RouteArea("Member")]
    public class MyTicketController : Controller
    {

        Context context = new Context();  
        
        public ActionResult TicketList()
        {
            var values = context.Tickets.ToList();
            return View(values);
        }
        public ActionResult MyTicketList()
        {
            int userId = (int)Session["UserId"];

            var tickets = (from ut in context.UserTickets
                           join t in context.Tickets on ut.TicketId equals t.TicketID
                           where ut.UserId == userId
                           select new UserTicketViewModel
                           {
                               TicketId = t.TicketID,
                               Title = t.Title,
                               Description = t.Description,
                               UserId = ut.UserId,
                               UserTicketId = ut.UserTicketID,
                                Price= t.Price
                               
                           }).ToList();

            return View(tickets);
        }


    
    }
}