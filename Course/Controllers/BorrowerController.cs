using Course.Models;
using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            /*
            if (!TryUpdateModel(model))
            {
                return View(model);
            }
            */

            

            borrowerRepository.saveBorrower(model.заёмщик);

            return Redirect("/Borrower/Show");
        }
    }
}