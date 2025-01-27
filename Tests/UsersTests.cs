using Microsoft.EntityFrameworkCore;
using Moq;
using TaskManager.Application.Users.Register;
using TaskManager.Data;

namespace Tests
{
    public class UsersTests
    {
        [Fact]
        public void RegisterUser_ShouldReturnSuccess_WhenValidRequest()
        {
            var options = new DbContextOptionsBuilder<TaskManagerDbContext>()
                .UseInMemoryDatabase(databaseName: "TaskManagerDb")
                .Options;

            using (var context = new TaskManagerDbContext(options))
            {
                var handler = new Handler(context);

                var request = new Request
                {
                    Username = "testuser",
                    Password = "password123",
                    Name = "Test User"
                };

                var response = handler.Handle(request, default).Result;

                Assert.True(response.Success);
            }
        }
    }
    }