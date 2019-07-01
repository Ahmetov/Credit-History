using Course.Repository;
using System.Linq;
using System.Net;
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
            история.Количество_Заявок = 0;

            return View(история);
        }

        public ActionResult Show()
        {
            return View(repository.GetAllHistories());
        }

        [HttpPost]
        public ActionResult Show(int? id)
        {
            if( id != null)
            {
                return View(repository.findHistoryById(id.Value));
            }

            return Redirect("/History/Show");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Кредитная_История история = repository.findHistoryById(id.Value).FirstOrDefault();
            
            return View(история);
        }

        [HttpPost]
        public ActionResult Update(Кредитная_История model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            repository.update(model);
            return Redirect("/History/Show");
        }

        [HttpPost]
        public ActionResult Create(Кредитная_История model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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


    }
}