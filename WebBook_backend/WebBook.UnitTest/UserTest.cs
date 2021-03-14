using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Business;
using Xunit;

namespace WebBook.UnitTest
{
    public class UserTest
    {
        [Fact]
        public void CreateUser_Success()
        {
            Mock<IUserOperation> mockUserControl = new Mock<IUserOperation>();
            mockUserControl.Setup(x => x.Encrypt("abc")).Returns("test");
            mockUserControl.Setup(x => x.WriteToFile(It.IsAny<WebBook.Data.User>())).Returns(new WebBook.Data.FileResult { IsSuccess = true });
            UserOperation userOperation = new UserOperation();

            var result = userOperation.Create(new WebBook.Data.User { UserName = "ceyda_nur", Password = "123456" });
            Assert.True(result.IsSuccess);
        }

        [Fact]

        public void CreateUser_UserName_Empty()
        {
            
            UserOperation userOperation = new UserOperation();

            Assert.Throws<Exception>(() => userOperation.Create(new WebBook.Data.User { UserName = string.Empty }));
        }
    }
}
