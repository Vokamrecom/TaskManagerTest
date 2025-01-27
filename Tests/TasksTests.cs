using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Tasks.Create;
using TaskManager.Data;

namespace Tests
{
    public class TasksTests
    {
        //[Fact]
        //public void CreateTask_ShouldReturnSuccess_WhenValidRequest()
        //{
        //    var mockSet = new Mock<DbSet<TaskManager.Data.Task>>();
        //    var mockContext = new Mock<TaskManagerDbContext>();
        //    mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);

        //    var handler = new Handler(mockContext.Object);

        //    var request = new Request
        //    {
        //        Title = "Test Task",
        //        Description = "Description",
        //        EstimatedCompletion = DateTime.UtcNow.AddDays(1)
        //    };

        //    var response = handler.Handle(request, default).Result;

        //    Assert.True(response.Success);
        //}
    }
}
