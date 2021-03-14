using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
   public class CommentOperation : ICommentOperation
    {

        public CommentOperation()
        {
        }

        public CommentResult AddComment(Comment comment)
        {
            if (string.IsNullOrEmpty(comment.Book))
                throw new Exception("UserNameEmpty");
           
            CommentWriteToFile(comment);


            return new CommentResult { IsSuccess = true };
        }

        public List<CommentResult> ListComment()
        { 
            return CommentAllReadFromFile();   

        }
        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\yorum.txt";


        public CommentResult CommentWriteToFile(Comment comment)
        {
            using (StreamWriter w = File.AppendText(FILE_PATH))
            {
                w.WriteLine(string.Format("{0};{1};{2}", comment.Book, comment.User, comment.CommentText));
                w.Flush();
            }

            return new CommentResult { IsSuccess = true };
        }


        public Comment CommentReadFromFile(string title)
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
                        return new Comment { Book = splitedLine[0], User = splitedLine[1], CommentText = splitedLine[2] };
                    }

                }

            }

            throw new NotImplementedException();
        }
        public List<CommentResult> CommentAllReadFromFile()
        {
            List<CommentResult> commentlist = new List<CommentResult>();
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {
                bool isFileEnd = true;

                while (isFileEnd)
                {
                    CommentResult comment = new CommentResult();

                    string line = fileReader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;


                    var splitedLine = line.Split(';');

                    comment.Book = splitedLine[0];
                    comment.User = splitedLine[1];
                    comment.CommentText = splitedLine[2];

                    commentlist.Add(comment);

                }

                return commentlist;

            }

            throw new NotImplementedException();
        }




    }
}
