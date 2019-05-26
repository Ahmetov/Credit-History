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
            return View(new Заёмщик());
        }

        [HttpPost]
        public ActionResult Create(Заёмщик model)
        {
            /*
            if (!TryUpdateModel(model))
            {
                return View(model);
            }
            */

            borrowerRepository.saveBorrower(model);

            return Redirect("/Borrower/Show");
        }
    }
}