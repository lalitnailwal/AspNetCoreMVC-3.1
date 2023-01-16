﻿using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess= false, int bookId = 0)
        {
            var model = new BookModel()
            {
                Language = "3"
            };

            ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            {
                Text = x.Text,
                Value = x.Id.ToString()
            });

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            {
                Text = x.Text,
                Value = x.Id.ToString()
            });

            //ModelState.AddModelError("","This is custom error message"); //Will be shown in validation summary with Model only as attribute

            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() {Id = 1, Text = "English"},
                new LanguageModel() {Id = 2, Text = "Hindi"},
                new LanguageModel() {Id = 3, Text = "Dutch"}
            };
        }
    }
}
