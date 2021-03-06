﻿using GoodBooks.Data.Models;
using GoodBooks.Services;
using GoodBooks.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GoodBooks.Web.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("/api/books")]
        public ActionResult GetBooks(){
            //return Ok("Books!");
            var books = _bookService.GetAllBooks();
            //Maybe normally we have a logic to check if we have any book back.
            //If we don't have book(s), we would return a service-response with a meaasge "No books found?" back IE.
            //NOTE, normally, we would never return a data model like we do hare!
            //We normally MAP them to a VIEW-MODEL before returning it.
            return Ok(books); // return Okay response and the book instace 
         }

        [HttpGet("/api/books/{id}")]
        public ActionResult GetBook(int id)
        {
            //return Ok("Books!");
            var book = new Book();
            book = _bookService.GetBook(id);
            //Maybe normally we have a logic to check if we have any book back.
            //If we don't have book(s), we would return a service-response with a meaasge "No books found?" back IE.
            //NOTE, normally, we would never return a data model like we do hare!
            //We normally MAP them to a VIEW-MODEL before returning it.
            if (book != null)
            {
                return Ok(book); // return Okay response and the book instace 
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("/api/books/{id}")]
        public ActionResult DeleteBook(int id)
        {

            var bookToDelete = _bookService.GetBook(id);
            // VOID type method 
            //book = _bookService.GetBook(id); 
            _bookService.DeleteBook(id);
            return Ok($"Book Delete Id: {id} " ); // return Okay response and the book instace 
        }

        [HttpPost("/api/books")]
        public ActionResult CreateBook([FromBody] NewBookRequst bookRequest)
        {

            if (!ModelState.IsValid)
            { 
                return BadRequest("Model state is not valid!"); 
            }
            var now = DateTime.UtcNow; 

            var book = new Book
            {
                CreatedOn = now,
                UpdatedOn = now,
                Title = bookRequest.Title,
                Author = bookRequest.Author
            };

            _bookService.AddBook(book);
            
            return Ok($"Book Created: {book}"); 
        }
    }
}
