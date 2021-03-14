using System;
using System.Collections.Generic;
using System.Text;

namespace WebBook.Data
{
    public class LoginResult : ResultMessage
    {
        public DateTime LoginTime { get; set; }
        public string Message { get; set; }
    }
}
