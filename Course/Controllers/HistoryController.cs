using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!repository.deleteHistoryById(id.Value))
            {
                return HttpNotFound();
            }

            return RedirectToAction("/History/Show");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)//int id)
        {
            repository.deleteHistoryById(id);
            return Redirect("/History/Show");
        }
    }
}