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

        EFBankRepository bankRepository = new EFBankRepository();

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
            ViewBag.BorrowersDrop = borrowerRepository.GetBorrowers().Select(x => new SelectListItem { Text = (x.ИД_Заёмщика.ToString() + " " + x.Имя + " " + x.Фамилия), Value = x.ИД_Заёмщика.ToString()});
            ViewBag.BankDrop = bankRepository.GetBanks().Select(x => new SelectListItem { Text = (x.ИД_Банка.ToString() + " " + x.Название.ToString()), Value = x.ИД_Банка.ToString()});

            return View(договор);
        }

        [HttpPost]
        public ActionResult Create(Кредитный_Договор model)
        {
            loanRepository.saveLoan(model);

            return Redirect("/Loan/Show");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.BorrowersDrop = borrowerRepository.GetBorrowers().Select(x => new SelectListItem { Text = (x.ИД_Заёмщика.ToString() + " " + x.Имя + " " + x.Фамилия), Value = x.ИД_Заёмщика.ToString() });
            ViewBag.BankDrop = bankRepository.GetBanks().Select(x => new SelectListItem { Text = (x.ИД_Банка.ToString() + " " + x.Название.ToString()), Value = x.ИД_Банка.ToString() });

            Кредитный_Договор договор = loanRepository.findLoanById(id.Value);
            
            return View(договор);
        }

        [HttpPost]
        public ActionResult Update(Кредитный_Договор model)
        {
            loanRepository.update(model);
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

            return RedirectToAction("/Show");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)//int id)
        {
            loanRepository.deleteLoanById(id);
            return Redirect("/Show");
        }
    }
}