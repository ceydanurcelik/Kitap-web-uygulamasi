using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business


{
    public interface IBookOperation
    {
        BookResult AddBook(Book book);
        List<BookResult> ListBook();
        BookResult BookWriteToFile(Book book);
        Book BookReadFromFile(string title);
        List<BookResult> BookAllReadFromFile(String sel);
    }
}
