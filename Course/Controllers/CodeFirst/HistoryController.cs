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
        EFBorrowerRepository borrowerRepository = new EFBorrowerRepository();


        public ActionResult Create()
        {
            Кредитная_История история = new Кредитная_История();
            ViewBag.BorrowersDrop = borrowerRepository.GetBorrowers().Select(x => new SelectListItem { Text = (x.ИД_Заёмщика.ToString() + " " + x.Имя + " " + x.Фамилия), Value = x.ИД_Заёмщика.ToString() });

            return View(история);
        }

        public ActionResult Show()
        {
            return View(repository.GetHistories());
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //ViewBag.BorrowersDrop = borrowerRepository.GetBorrowers().Select(x => new SelectListItem { Text = (x.ИД_Заёмщика.ToString() + " " + x.Имя + " " + x.Фамилия), Value = x.ИД_Заёмщика.ToString() });

            Кредитная_История история = repository.findHistoryById(id.Value);
            
            return View(история);
        }

        [HttpPost]
        public ActionResult Update(Кредитная_История model)
        {
            repository.update(model);
            return Redirect("/Loan/Show");
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

            return RedirectToAction("/Show");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)//int id)
        {
            repository.deleteHistoryById(id);
            return Redirect("/Show");
        }
    }
}