using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class HomeController : Controller
    {
        EFBorrowerRepository borrowerRepository = new EFBorrowerRepository();

        public ActionResult Index()
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
            if (!TryUpdateModel(model))
            {
                return View(model);
            }

            borrowerRepository.saveBorrower(model);

            return View("Index", model);
        }

    }
}