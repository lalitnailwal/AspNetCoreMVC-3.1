using BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author == authorName).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =1, Title = "MVC", Author ="Lalit"},
                new BookModel(){Id =2, Title = "MVC", Author ="Prema"},
                new BookModel(){Id =3, Title = "C#", Author ="Akshat"},
                new BookModel(){Id =4, Title = "Java", Author ="Jeevan"},
                new BookModel(){Id =5, Title = "Php", Author ="Kailash"}
            };
        }
    }
}
