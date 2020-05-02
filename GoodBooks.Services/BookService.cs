using System;
using System.Collections.Generic;
using GoodBooks.Data;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        //create private read-only backing field
        private readonly GoodBooksDBContext _db;
        public BookService(GoodBooksDBContext db)
        {
            _db = db;
        }
        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int BookId)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int BookId)
        {
            throw new NotImplementedException();
        }
    }
}
