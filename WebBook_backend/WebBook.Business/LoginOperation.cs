using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business


{
    public class LoginOperation : ILoginOperation
    {
        private readonly IUserOperation UserOperation;

        public LoginOperation(IUserOperation UserOperation)
        {
            this.UserOperation = UserOperation;
        }
        public LoginResult Login(LoginRequest loginRequest)
        {
            User user = UserOperation.ReadFromFile(loginRequest.UserName);
            var encryptedPassword = UserOperation.Encrypt(loginRequest.Password);
            if (user.Password == encryptedPassword)
                return new LoginResult { IsSuccess = true, LoginTime = DateTime.Now };

            return new LoginResult { IsSuccess = false, Message = "WrongPassword" };



        }
    }
}
