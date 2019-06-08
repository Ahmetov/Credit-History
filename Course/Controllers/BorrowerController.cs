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

        public ActionResult Show()
        {
        
            return View(borrowerRepository.GetBorrowers());
        }

        public ActionResult Create()
        {
            ЗаёмщикАдрес заёмщикАдрес =  new ЗаёмщикАдрес();


            //return View(new Заёмщик());
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)//int id)
        {
            borrowerRepository.deleteBorrowerById(id);
            return Redirect("/Borrower/Show");
        }
    }
}