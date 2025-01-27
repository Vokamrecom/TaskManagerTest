using Microsoft.EntityFrameworkCore;
using Moq;
using TaskManager.Application.Users.Login;
using TaskManager.Data;

namespace Tests
{
    public class AuthenticationTests
    {
        //    [Fact]
        //    public void Login_ShouldReturnSuccess_WhenValidCredentials()
        //    {
        //        var mockSet = new Mock<DbSet<User>>();
        //        var mockContext = new Mock<TaskManagerDbContext>();
        //        mockContext.Setup(m => m.Users).Returns(mockSet.Object);

        //        var handler = new Handler(mockContext.Object);

        //        var request = new Request
        //        {
        //            Username = "testuser",
        //            Password = "password123"
        //        };

        //        var response = handler.Handle(request, default).Result;

        //        Assert.True(response.Success);
        //    }
        //}
    }
}
