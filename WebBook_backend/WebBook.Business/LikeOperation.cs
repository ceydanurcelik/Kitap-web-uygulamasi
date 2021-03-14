using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebBook.Data;

namespace WebBook.Business


{
   public class LikeOperation : ILikeOperation
    {

        public LikeOperation()
        {
        }

        public LikeResult AddLike(Like like)
        {
            if (string.IsNullOrEmpty(like.Book))
                throw new Exception("UserNameEmpty");
           
           LikeWriteToFile(like);


            return new LikeResult { IsSuccess = true };
        }

        public List<LikeResult> ListLike()
        {
            return LikeAllReadFromFile();   
        }

        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\begeni.txt";


        public LikeResult LikeWriteToFile(Like like)
        {
            using (StreamWriter w = File.AppendText(FILE_PATH))
            {
                w.WriteLine(string.Format("{0};{1}", like.Book, like.User));
                w.Flush();
            }

            return new LikeResult { IsSuccess = true };
        }


        public Like LikeReadFromFile(string title)
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
                        return new Like { Book = splitedLine[0], User = splitedLine[1] };
                    }

                }

            }

            throw new NotImplementedException();
        }
        public List<LikeResult> LikeAllReadFromFile()
        {
            List<LikeResult> likelist = new List<LikeResult>();
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
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

                return likelist;

            }

            throw new NotImplementedException();
        }


    }
}
