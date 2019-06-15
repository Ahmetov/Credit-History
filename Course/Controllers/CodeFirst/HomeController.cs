using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class HomeController : Controller
    {
        EFHistoryRepositroy repositroy = new EFHistoryRepositroy();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find()
        {
            Кредитная_История история = new Кредитная_История();
            return View();
        }

        [HttpPost]
        public ActionResult Find(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return Redirect("/Home/Finded/" + id);
        }

        public ActionResult Finded(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Кредитная_История история = repositroy.findHistoryByPassport(id.Value);

            if (история == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } else
                return View(история);
        }


    }
}