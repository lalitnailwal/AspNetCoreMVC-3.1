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
                new BookModel(){Id =1, Title = "MVC", Author ="Lalit", Description = "This is a description for MVC book"},
                new BookModel(){Id =2, Title = "Dot Net Core", Author ="Prema", Description = "This is a description for Dot Net Core book"},
                new BookModel(){Id =3, Title = "C#", Author ="Akshat", Description = "This is a description for C# book"},
                new BookModel(){Id =4, Title = "Java", Author ="Jeevan", Description = "This is a description for Java book"},
                new BookModel(){Id =5, Title = "Php", Author ="Kailash", Description = "This is a description for Php book"},
                new BookModel(){Id =5, Title = "Azure Devops", Author ="Nitin", Description = "This is a description for Azure Devops book"}
            };
        }
    }
}
