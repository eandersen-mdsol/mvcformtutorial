using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForms.ViewModels;

namespace MVCForms.Controllers
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save the new book
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

    }
}
