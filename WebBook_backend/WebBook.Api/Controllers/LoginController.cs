using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBook.Data;
using WebBook.Business;

namespace WebBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginOperation LoginOperation;
        private readonly IUserOperation UserOperation;
        public LoginController(ILoginOperation LoginOperation, IUserOperation UserOperation)
        {
            this.LoginOperation = LoginOperation;
            this.UserOperation = UserOperation;
        }




        [HttpPost("Create")]
        public UserResult Create([FromBody] User user)
        {
            return UserOperation.Create(user);
        }

        [HttpPost("Login")]
        public LoginResult Login([FromBody] LoginRequest loginRequest)
        {
            return LoginOperation.Login(loginRequest);
        }
    }
}
