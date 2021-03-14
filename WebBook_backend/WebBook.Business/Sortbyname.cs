using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public class Sortbyname
    {

        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\kitap.txt";
        private const string FILE_PATH2 = "C:\\Users\\ASUS\\Desktop\\web\\sortbyname.txt";
        public List<String> listharf;
        public List<Book> BookAllReadFromFile()
        {
            List<Book> booklist = new List<Book>();
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {
                bool isFileEnd = true;

                while (isFileEnd)
                {
                    Book book = new Book();

                    string line = fileReader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;


                    var splitedLine = line.Split(';');
                    book.Title = splitedLine[0];
                    book.Comment = splitedLine[1];
                    book.Author = splitedLine[2];
                    book.User = splitedLine[3];

                    booklist.Add(book);
                  
                    listharf.Add(splitedLine[0]);
                }
                
                return booklist;

            }

            throw new NotImplementedException();
        }
        public BookResult BookWriteToFile(Book book)
        {
            using (StreamWriter w = File.AppendText(FILE_PATH2))
            {
                w.WriteLine(string.Format("{0};{1};{2};{3}", book.Title, book.Comment, book.Author, book.User));
                w.Flush();
            }

            return new BookResult { IsSuccess = true };
        }

        public BookResult SortName()
        {
            var i = 0;
            BookResult b = new BookResult();
            List<Book> oldlist, newlist;
            oldlist = BookAllReadFromFile();
            

            for (i = 0; i < 50; i++)
            {
                List<Book> artanSiralama = oldlist.OrderByDescending(item => item).ToList();
                foreach (Book lr in artanSiralama)
                {
                    b = BookWriteToFile(lr);
                }
            }



            return b;

        }




    }
}
