using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var newBook = new Books
            {
                Author = bookModel.Author,
                CreatedOn = DateTime.UtcNow,
                Description = bookModel.Description,
                Title = bookModel.Title,
                LanguageId = bookModel.LanguageId,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = bookModel.CoverImageUrl,
                BookPdfUrl = bookModel.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in bookModel.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery() 
                { 
                    Name = file.Name, 
                    URL = file.URL
                });

            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                }).ToListAsync();
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                }).Take(count).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select(g => new GalleryModel() 
                    { 
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl
                }).FirstOrDefaultAsync();
        }
    }

    //public List<BookModel> SearchBooks(string title, string authorName)
    //{
    //    return null;
    //}
}