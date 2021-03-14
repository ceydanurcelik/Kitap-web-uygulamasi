using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public class Sorting : ISorting
    {
        public Sorting()
        {

        }

        public SortResult AddSort(Sort sort)
        {
            if (string.IsNullOrEmpty(sort.SelectionSort))
                throw new Exception("UserNameEmpty");

            SortWriteToFile(sort);


            return new SortResult { IsSuccess = true };
        }

        public SortResult ListSort()
        {
            return SortAllReadFromFile();
        }

        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\sort.txt";


        public SortResult SortWriteToFile(Sort sort)
        {
            using (StreamWriter w = new StreamWriter(FILE_PATH))
            {

                w.Write(string.Format("{0}", sort.SelectionSort));
                w.Flush();
            }

            return new SortResult { IsSuccess = true };
        }


        public Sort SortrReadFromFile()
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

                    return new Sort { SelectionSort = splitedLine[0] };


                }

            }

            throw new NotImplementedException();
        }
        public SortResult SortAllReadFromFile()
        {
            SortResult sort = new SortResult();
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {

                string line = fileReader.ReadLine();
                var splitedLine = line.Split(';');
                sort.SelectionSort = splitedLine[0];
                return sort;

            }

            throw new NotImplementedException();
        }
    }
}
