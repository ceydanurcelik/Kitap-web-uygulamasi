using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
   public interface IReadOperation
    {
        ReadResult AddRead(Read read);
        List<ReadResult> ListRead();
        ReadResult ReadWriteToFile(Read read);
        Read ReadReadFromFile(string title);
        List<ReadResult> ReadAllReadFromFile();
    }
}
