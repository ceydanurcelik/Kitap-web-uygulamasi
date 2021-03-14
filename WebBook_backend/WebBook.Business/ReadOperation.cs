using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public class ReadOperation : IReadOperation
    {
        public ReadOperation()
        {
        }

        public ReadResult AddRead(Read read)
        {
            if (string.IsNullOrEmpty(read.Book))
                throw new Exception("UserNameEmpty");

            ReadWriteToFile(read);


            return new ReadResult { IsSuccess = true };
        }

        public List<ReadResult> ListRead()
        {
            return ReadAllReadFromFile();
        }

        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\read.txt";


        public ReadResult ReadWriteToFile(Read read)
        {
            using (StreamWriter w = File.AppendText(FILE_PATH))
            {
                w.WriteLine(string.Format("{0};{1}", read.Book, read.User));
                w.Flush();
            }

            return new ReadResult { IsSuccess = true };
        }


        public Read ReadReadFromFile(string title)
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
                        return new Read { Book = splitedLine[0], User = splitedLine[1] };
                    }

                }

            }

            throw new NotImplementedException();
        }
        public List<ReadResult> ReadAllReadFromFile()
        {
            List<ReadResult> likelist = new List<ReadResult>();
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {
                bool isFileEnd = true;

                while (isFileEnd)
                {
                    ReadResult like = new ReadResult();

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
