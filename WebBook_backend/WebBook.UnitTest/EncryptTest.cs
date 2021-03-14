using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Business;
using Xunit;

namespace WebBook.UnitTest
{
    public class EncryptTest
    {
        [Fact]
        public void EncryptSuccess()
        {
            
            UserOperation encryptoperation = new UserOperation();
            var result = encryptoperation.Encrypt("abc");     
            Assert.Equal("979899", result);    
        }
    }
}
