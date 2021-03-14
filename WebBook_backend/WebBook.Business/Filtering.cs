using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public class Filtering : IFiltering
    {
        public Filtering()
        {

        }

        public FilteringResult AddFilter(Filter filter)
        {
            if (string.IsNullOrEmpty(filter.Selection))
                throw new Exception("UserNameEmpty");

            FilterWriteToFile(filter);


            return new FilteringResult { IsSuccess = true };
        }

        public FilteringResult ListFilter()
        {
            return FilterAllReadFromFile();
        }

        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\filtreleme.txt";


        public FilteringResult FilterWriteToFile(Filter filter)
        {
            using (StreamWriter w = new StreamWriter(FILE_PATH))
            {
                
                w.Write(string.Format("{0}", filter.Selection));
                w.Flush();
            }

            return new FilteringResult { IsSuccess = true };
        }


        public Filter FilterReadFromFile()
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
                    
                        return new Filter { Selection = splitedLine[0] };
                  

                }

            }

            throw new NotImplementedException();
        }
        public FilteringResult FilterAllReadFromFile()
        {
            FilteringResult filter = new FilteringResult();
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {
               
                string line = fileReader.ReadLine();
                var splitedLine = line.Split(';');
                filter.Selection = splitedLine[0];
                return filter;

            }

            throw new NotImplementedException();
        }




    }
}
