using Course.Models.Util;
using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class LoanController : Controller
    {
        EFLoanRepository loanRepository = new EFLoanRepository();

        EFBorrowerRepository borrowerRepository = new EFBorrowerRepository();

        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            return View(loanRepository.GetLoans());
        }

        public ActionResult Create()
        {
            DropDownBorrower dropDown = new DropDownBorrower();

            List<SelectListItem> listItems = new List<SelectListItem>();

            Кредитный_Договор договор = new Кредитный_Договор();
            ViewBag.DropDownValues = new SelectList(borrowerRepository.GetBorrowers());

            return View(договор);
        }

        [HttpPost]
        public ActionResult Create(Кредитный_Договор model)
        {

            loanRepository.saveLoan(model);

            return Redirect("/Loan/Show");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!loanRepository.deleteLoanById(id.Value))
            {
                return HttpNotFound();
            }

            return RedirectToAction("/Loan/Show");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)//int id)
        {
            loanRepository.deleteLoanById(id);
            return Redirect("/Loan/Show");
        }
    }
}