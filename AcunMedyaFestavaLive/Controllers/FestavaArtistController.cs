using AcunMedyaFestavaLive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaFestavaLive.Controllers
{
    public class FestavaArtistController : Controller
    {
        // GET: FestavaArtist
        Context context = new Context();
        public ActionResult ArtistList()
        {
            var values = context.Artists.ToList();
            return View(values);
        }
    }
}