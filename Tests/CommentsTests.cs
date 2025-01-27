using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Comments.Add;
using TaskManager.Data;

namespace Tests
{
    public class CommentsTests
    {
        //[Fact]
        //public void AddComment_ShouldReturnSuccess_WhenValidRequest()
        //{
        //    var options = new DbContextOptionsBuilder<TaskManagerDbContext>()
        //       .UseInMemoryDatabase(databaseName: "TaskManagerDb")
        //       .Options;

        //    using (var context = new TaskManagerDbContext(options))
        //    {

        //        var handler = new Handler(context);

        //        var request = new Request
        //        {
        //            TaskId = 1,
        //            Content = "This is a comment"
        //        };

        //        var response = handler.Handle(request, default).Result;

        //        Assert.True(response.Success);
        //    }
        //}
    }
}
