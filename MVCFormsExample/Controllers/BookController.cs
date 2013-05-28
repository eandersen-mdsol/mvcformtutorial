using System.Web.Mvc;
using MVCFormsExample.ViewModels;

namespace MVCFormsExample.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new BookViewModel());
        }

        [HttpPost]
        public ActionResult Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save book
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
