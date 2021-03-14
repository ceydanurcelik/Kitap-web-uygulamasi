using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBook.Data;
using WebBook.Business;

namespace WebBook.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookOperation BookOperation;
        public BookController(IBookOperation BookOperation)
        {
            this.BookOperation = BookOperation;
        }

        [HttpPost("createbook")]
        public BookResult AddBook(Book book)
        {
            return BookOperation.AddBook(book);
        }

        [HttpGet("GetBookList")]
        public List<BookResult> GetBookList()
        {
            return BookOperation.ListBook();
        }
    }
}

