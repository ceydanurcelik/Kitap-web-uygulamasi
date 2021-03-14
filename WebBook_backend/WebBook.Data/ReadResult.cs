using System;
using System.Collections.Generic;
using System.Text;

namespace WebBook.Data
{
    public class ReadResult :ResultMessage
    {
        public string Book { get; set; }
        public string User { get; set; }
    }
}
