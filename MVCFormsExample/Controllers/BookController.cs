using System;
using System.Web.Mvc;
using MVCFormsExample.Models;
using MVCFormsExample.Repositories;
using MVCFormsExample.ViewModels;

namespace MVCFormsExample.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepository = new StaticBookRepository();

        public ActionResult Index()
        {
            return View(bookRepository.All);
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
                viewModel.Id = Guid.NewGuid();
                var book = new Book();
                UpdateBook(book, viewModel);
                bookRepository.Upsert(book);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var book = bookRepository.GetById(id);
            if (book == null) return new HttpNotFoundResult();
            return View(ViewModelFromBook(book));
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingBook = bookRepository.GetById(viewModel.Id);
                UpdateBook(existingBook, viewModel);
                bookRepository.Upsert(existingBook);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        private BookViewModel ViewModelFromBook(Book book)
        {
            var viewModel = new BookViewModel
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    DatePublished = book.Published,
                    Rating = book.Rating
                };
            return viewModel;
        }

        private void UpdateBook(Book book, BookViewModel viewModel)
        {
            book.Id = viewModel.Id;
            book.Author = viewModel.Author;
            book.Name = viewModel.Name;
            book.Published = viewModel.DatePublished.GetValueOrDefault();
            book.Rating = viewModel.Rating;
        }
    }
}
