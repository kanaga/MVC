using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Promotion.Model;

namespace Promotion.Web.Controllers
{
    public class PromotionController : Controller
    {
        //
        // GET: /Promotion/
      //  public  db =  new Promotion();

        public ActionResult Index()
        {
            var promo = new MainPromo { HeaderBanner = "test", CreateDate = DateTime.Today, Display = true, FooterDisclaimer = "test2" };
            var db = new Promotion.Model.Promotion();
            db.MainPromos.Add(promo);
            return View();
        }

    }
}
