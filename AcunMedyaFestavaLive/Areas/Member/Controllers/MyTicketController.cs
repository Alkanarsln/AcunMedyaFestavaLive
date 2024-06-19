using AcunMedyaFestavaLive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaFestavaLive.Areas.Member.Controllers
{
    [RouteArea("Member")]
    public class MyTicketController : Controller
    {

        Context context = new Context();  
        
        public ActionResult MyTicketList()
        {
            
            return View();
        }
    
    }
}