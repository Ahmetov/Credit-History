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
            Кредитный_Договор договор = new Кредитный_Договор();

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