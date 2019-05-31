using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class HistoryController : Controller
    {
        EFHistoryRepositroy repository = new EFHistoryRepositroy();

        public ActionResult Create()
        {
            Кредитная_История история = new Кредитная_История();

            return View(история);
        }

        public ActionResult Show()
        {
            return View(repository.GetHistories());
        }

        [HttpPost]
        public ActionResult Create(Кредитная_История model)
        {
            repository.saveHistory(model);

            return Redirect("/History/Show");
        }
    }
}