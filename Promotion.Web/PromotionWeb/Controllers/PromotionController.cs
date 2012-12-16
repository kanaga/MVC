using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Promotion.Repository;

namespace PromotionWeb.Controllers
{
    public class PromotionController : Controller
    {
        //
        // GET: /Promotion/
        Promotion.Repository.Promotion db = new Promotion.Repository.Promotion();

        public ActionResult Index()
        {
            //var promo = new MainPromo { HeaderBanner = "test",  StartDate=DateTime.Today, EndDate=DateTime.Today.AddDays(1),CreateDate =DateTime.Today, Display = true, FooterDisclaimer = "test2" };
            //db.MainPromos.Add(promo);
            //db.SaveChanges();
            var model = db.MainPromos.ToList();

            return View(model);
        }

    }
}
