using System;
using System.Linq;
using System.Collections.Generic;
using GoodBooks.Data;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        //create private read-only backing field
        private readonly GoodBooksDbContext _db;
        public BookService(GoodBooksDbContext db)
        {
            _db = db;
        }
        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int BookId)
        {
            try{
            var bookToDelete = _db.Books.FirstOrDefault(s => s.Id == BookId);
            if(bookToDelete != null){
                _db.Books.Remove(bookToDelete);
                _db.SaveChanges();
            }
            }catch(Exception){

                throw new InvalidOperationException("Cant delete Book");
            }

        }

        public List<Book> GetAllBooks()
        {
            var books = _db.Books.ToList();
            return books;
        }

        public Book GetBook(int BookId)
        {
            var book = _db.Books.FirstOrDefault(c => c.Id == BookId);
            return book;
        }
    }
}
