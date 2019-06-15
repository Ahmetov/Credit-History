using Course.Models;
using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class BorrowerController : Controller
    {
        EFBorrowerRepository borrowerRepository = new EFBorrowerRepository();
        EFHistoryRepositroy historyRepositroy = new EFHistoryRepositroy();

        public ActionResult Show()
        {
            return View(borrowerRepository.GetBorrowers());
        }

        public ActionResult Create()
        {
            ЗаёмщикАдрес заёмщикАдрес =  new ЗаёмщикАдрес();
            ViewBag.HistoryDrop = historyRepositroy.GetHistories().Select(x => new SelectListItem { Text = ( "ID: " + x.ИД_Кредитной_Истории.ToString()), Value = x.ИД_Кредитной_Истории.ToString() });
            return View(заёмщикАдрес);
        }

        [HttpPost]
        public ActionResult Create(ЗаёмщикАдрес model)
        {
            borrowerRepository.saveBorrower(model.заёмщик);
            return Redirect("/Borrower/Show");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!borrowerRepository.deleteBorrowerById(id.Value))
            {
                return HttpNotFound();
            }

            return RedirectToAction("/Show");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.HistoryDrop = historyRepositroy.GetHistories().Select(x => new SelectListItem { Text = ("ID: " + x.ИД_Кредитной_Истории.ToString()), Value = x.ИД_Кредитной_Истории.ToString() });

            Заёмщик заёмщик = borrowerRepository.GetBoorrowerById(id.Value);
            ЗаёмщикАдрес заёмщикАдрес = new ЗаёмщикАдрес();
            заёмщикАдрес.заёмщик = заёмщик;
            заёмщикАдрес.адрес = заёмщик.Адрес;

            return View(заёмщикАдрес);
        }

        [HttpPost]
        public ActionResult Update(ЗаёмщикАдрес model)
        {
            model.заёмщик.ИД_Адреса = model.адрес.ИД_Адреса;
            borrowerRepository.update(model);
            return Redirect("/Borrower/Show");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            borrowerRepository.deleteBorrowerById(id);
            return Redirect("/Borrower/Show");
        }
    }
}