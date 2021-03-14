using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business


{
    public interface IUserOperation
    {
        UserResult Create(User user);
        string Encrypt(string password);
        FileResult WriteToFile(User user);
        User ReadFromFile(string userName);
    }
}
