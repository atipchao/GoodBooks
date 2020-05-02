using System.Collections.Generic;
namespace GoodBooks.Services
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBook(int BookId);
        public void AddBook(Book book);
        public void DeleteBook(int BookId);
        
    }     

}