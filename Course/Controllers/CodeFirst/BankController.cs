﻿using Course.Models;
using Course.Repository;
using System.Net;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class BankController : Controller
    {
        EFBankRepository bankRepository = new EFBankRepository();

        public ActionResult Show()
        {
            return View(bankRepository.GetBanks());
        }

        public ActionResult Create()
        {
            БанкАдрес банкАдрес = new БанкАдрес();

            return View(банкАдрес);
        }

        [HttpPost]
        public ActionResult Show(string name)
        {
            return View(bankRepository.findByName(name));
        }

        [HttpPost]
        public ActionResult Create(БанкАдрес model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bankRepository.saveBank(model.банк);
            return Redirect("/Bank/Show");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Банк банк = bankRepository.findBankById(id.Value);
            БанкАдрес банкАдрес = new БанкАдрес();
            банкАдрес.банк = банк;
            банкАдрес.адрес = банк.Адрес;
            return View(банкАдрес);
        }

        [HttpPost]
        public ActionResult Update(БанкАдрес model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            model.банк.ИД_Адреса = model.адрес.ИД_Адреса;
            bankRepository.update(model);
            return Redirect("/Bank/Show");
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!bankRepository.deleteBankById(id.Value))
            {
                return HttpNotFound();
            }
            
            return RedirectToAction("/Show");
        }


    


    }
}