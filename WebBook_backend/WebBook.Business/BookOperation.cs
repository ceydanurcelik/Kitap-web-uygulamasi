using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public class BookOperation : IBookOperation
    {

        public BookOperation()
        {
        }

        public BookResult AddBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Title))
                throw new Exception("UserNameEmpty");

            BookWriteToFile(book);


            return new BookResult { IsSuccess = true };
        }

        public List<BookResult> ListBook()
        {
            var selection2 = "";

            using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\sort.txt"))
            {

                string line = fileReader.ReadLine();
                var splitedLine = line.Split(';');
                selection2 = splitedLine[0];
            }


            
            return BookAllReadFromFile(selection2);
           
        }
        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\kitap.txt";
        private const string FILE_PATH2 = "C:\\Users\\ASUS\\Desktop\\web\\kitap2.txt";






        public BookResult BookWriteToFile(Book book)
        {
            using (StreamWriter w = File.AppendText(FILE_PATH))
            {
                w.WriteLine(string.Format("{0};{1};{2};{3}", book.Title, book.Comment, book.Author, book.User));
                w.Flush();
            }
            using (StreamWriter w = File.AppendText(FILE_PATH2))
            {
                w.WriteLine(string.Format("{0};{1};{2};{3}", book.Title, book.Comment, book.Author, book.User));
                w.Flush();
            }

            return new BookResult { IsSuccess = true };
        }





        public Book BookReadFromFile(string title)
        {
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {
                bool isFileEnd = true;

                while (isFileEnd)
                {
                    string line = fileReader.ReadLine();
                    if (string.IsNullOrEmpty(line))

                        break;


                    var splitedLine = line.Split(';');
                    if (splitedLine[0] == title)
                    {
                        return new Book { Title = splitedLine[0], Comment = splitedLine[1], Author = splitedLine[2], User = splitedLine[3] };
                    }

                }

            }

            throw new NotImplementedException();
        }
        public List<BookResult> BookAllReadFromFile(String Sel)
        {

            if (Sel == "siralaalfabetik")       //alfabetik sıralama
            {
                List<BookResult> booklist3 = new List<BookResult>();
                using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\kitap.txt"))
                {
                    bool isFileEnd = true;

                    while (isFileEnd)
                    {
                        BookResult book = new BookResult();

                        string line = fileReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            break;


                        var splitedLine = line.Split(';');
                        book.Title = splitedLine[0];
                        book.Comment = splitedLine[1];
                        book.Author = splitedLine[2];
                        book.User = splitedLine[3];

                        booklist3.Add(book);
                    }


                }


                booklist3.Sort(delegate (BookResult x, BookResult y)
                {
                    if (x.Title == null && y.Title == null) return 0;
                    else if (x.Title == null) return -1;
                    else if (y.Title == null) return 1;
                    else return x.Title.CompareTo(y.Title);
                });


                File.WriteAllText("C:\\Users\\ASUS\\Desktop\\web\\sortbyname.txt", String.Empty);
                foreach (BookResult a in booklist3)
                {
                    using (StreamWriter w = File.AppendText("C:\\Users\\ASUS\\Desktop\\web\\sortbyname.txt"))
                    {
                        w.WriteLine(string.Format("{0};{1};{2};{3}", a.Title, a.Comment, a.Author, a.User));
                        w.Flush();
                    }
                }







            }       //alfabetik sıralama sonu




            if (Sel == "siralabegeni")       //begeni sıralama
            {

                List<BookResult> booklist2 = new List<BookResult>();
                using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\kitap.txt"))
                {
                    bool isFileEnd = true;

                    while (isFileEnd)
                    {
                        BookResult book = new BookResult();

                        string line = fileReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            break;


                        var splitedLine = line.Split(';');
                        book.Title = splitedLine[0];
                        book.Comment = splitedLine[1];
                        book.Author = splitedLine[2];
                        book.User = splitedLine[3];

                        booklist2.Add(book);
                    }


                }

                
                List<LikeResult> likelist = new List<LikeResult>();
                using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\begeni.txt"))
                {
                    bool isFileEnd = true;

                    while (isFileEnd)
                    {
                        LikeResult like = new LikeResult();
                        
                        string line = fileReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            break;


                        var splitedLine = line.Split(';');
                        like.Book = splitedLine[0];
                        like.User = splitedLine[1];

                        likelist.Add(like);
                    }

                }
                List<ToplamLike> listToplamLike = new List<ToplamLike>();
                foreach (var value in booklist2)
                {
                    var begenisayisi = 0;
                    ToplamLike liketop = new ToplamLike();
                    
                    foreach(var value2 in likelist)
                    {
                        if (value.Title == value2.Book)
                            begenisayisi++;
                    }
                    liketop.toplamlike = begenisayisi;
                    liketop.bookname = value.Title;
                    listToplamLike.Add(liketop);

                    
                }



                listToplamLike.Sort(delegate (ToplamLike x, ToplamLike y)
                {
                    if (x.toplamlike == null && y.toplamlike == null) return 0;
                    else if (x.toplamlike == null) return -1;
                    else if (y.toplamlike == null) return 1;
                    else return x.toplamlike.CompareTo(y.toplamlike);
                });

                 foreach (ToplamLike a in listToplamLike)
                    {
                        using (StreamWriter w = File.AppendText("C:\\Users\\ASUS\\Desktop\\web\\toplambegeni.txt"))
                        {
                            w.WriteLine(string.Format("{0};{1}", a.bookname, a.toplamlike));
                            w.Flush();
                        }
                    }


                //booklist2 de kitap txt bilgileri
                //listToplamLike da begeni bilgileri var
                var sayac = 0;

                File.WriteAllText("C:\\Users\\ASUS\\Desktop\\web\\sortbylike.txt", String.Empty);
                foreach (var a in listToplamLike)
                {
                    foreach(var b in booklist2)
                    {
                            if (a.bookname == b.Title)
                        {

                            using (StreamWriter w = File.AppendText("C:\\Users\\ASUS\\Desktop\\web\\sortbylike.txt"))
                            {
                                w.WriteLine(string.Format("{0};{1};{2};{3}", b.Title, b.Comment, b.Author, b.User));
                                w.Flush();
                            }



                        }

                   
                    }
                   

                }












            }       //begeni sıralama sonu


            if (Sel == "siralason")
            {

                List<BookResult> booklist4 = new List<BookResult>();
                using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\kitap.txt"))
                {
                    bool isFileEnd = true;

                    while (isFileEnd)
                    {
                        BookResult book = new BookResult();

                        string line = fileReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            break;


                        var splitedLine = line.Split(';');
                        book.Title = splitedLine[0];
                        book.Comment = splitedLine[1];
                        book.Author = splitedLine[2];
                        book.User = splitedLine[3];

                        booklist4.Add(book);
                    }


                }



                booklist4.Reverse();


                File.WriteAllText("C:\\Users\\ASUS\\Desktop\\web\\sortbyend.txt", String.Empty);
                foreach (BookResult a in booklist4)
                {
                    using (StreamWriter w = File.AppendText("C:\\Users\\ASUS\\Desktop\\web\\sortbyend.txt"))
                    {
                        w.WriteLine(string.Format("{0};{1};{2};{3}", a.Title, a.Comment, a.Author, a.User));
                        w.Flush();
                    }
                }





            }









            if (Sel == "siralaalfabetik")
            {



                List<BookResult> booklist = new List<BookResult>();
                using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\sortbyname.txt"))
                {
                    bool isFileEnd = true;

                    while (isFileEnd)
                    {
                        BookResult book = new BookResult();

                        string line = fileReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            break;


                        var splitedLine = line.Split(';');
                        book.Title = splitedLine[0];
                        book.Comment = splitedLine[1];
                        book.Author = splitedLine[2];
                        book.User = splitedLine[3];

                        booklist.Add(book);
                    }

                    return booklist;

                }
            }//if end


            if (Sel == "siralabegeni")
            {



                List<BookResult> booklist = new List<BookResult>();
                using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\sortbylike.txt"))
                {
                    bool isFileEnd = true;

                    while (isFileEnd)
                    {
                        BookResult book = new BookResult();

                        string line = fileReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            break;


                        var splitedLine = line.Split(';');
                        book.Title = splitedLine[0];
                        book.Comment = splitedLine[1];
                        book.Author = splitedLine[2];
                        book.User = splitedLine[3];

                        booklist.Add(book);
                    }

                    return booklist;

                }
            }//if end

            if (Sel == "siralason")
            {
                List<BookResult> booklist = new List<BookResult>();
                using (StreamReader fileReader = new StreamReader("C:\\Users\\ASUS\\Desktop\\web\\sortbyend.txt"))
                {
                    bool isFileEnd = true;

                    while (isFileEnd)
                    {
                        BookResult book = new BookResult();

                        string line = fileReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            break;


                        var splitedLine = line.Split(';');
                        book.Title = splitedLine[0];
                        book.Comment = splitedLine[1];
                        book.Author = splitedLine[2];
                        book.User = splitedLine[3];

                        booklist.Add(book);
                    }

                    return booklist;

                }






            }
                if (Sel != "siralaalfabetik")
            {

           

            List<BookResult> booklist = new List<BookResult>();
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {
                bool isFileEnd = true;

                while (isFileEnd)
                {
                    BookResult book = new BookResult();

                    string line = fileReader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;


                    var splitedLine = line.Split(';');
                    book.Title = splitedLine[0];
                    book.Comment = splitedLine[1];
                    book.Author = splitedLine[2];
                    book.User = splitedLine[3];

                    booklist.Add(book);
                }

                return booklist;

            }
            }//if end


            throw new NotImplementedException();
        }

    }
}
