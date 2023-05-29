using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Nest;
using NUnit.Framework;
using Project_Rectangle.Controllers;
using Project_Rectangle.Data;
using Project_Rectangle.Models;

namespace TestProject1
{
    [TestFixture]
    public class RectangleClassControllerTest
    {
        private static RectangleClassController _controller = null;

        public RectangleClassControllerTest()
        {
            // Initialize the controller with the mock repository
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(@"Server=LAPTOP-UUN94G25;Database=RectangleDB;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

            var context = new AppDbContext(contextOptions);

            _controller = new RectangleClassController(context);
        }

  

        [Test]
        public void SearchRectangles_ReturnsNotNull()
        {
            // Arrange
            List<Coordinate> coordinates = new List<Coordinate>
            {
                new Coordinate { X = 86, Y = 30 },
                new Coordinate { X = 79, Y = 95 }
            };
            
            // Act
            var result = _controller.Search(coordinates);
            Assert.IsNotNull(result);
           
        }

        [Test]
        public void SearchRectangles_ReturnsRectangleCount()
        {
            // Arrange
            List<Coordinate> coordinates = new List<Coordinate>
            {
                new Coordinate { X = 86, Y = 30 },
                new Coordinate { X = 79, Y = 95 }
            };

            // Act
            var result = _controller.Search(coordinates);
            var rst = result as OkObjectResult;

            if (rst != null)
            {
                var rc = rst.Value as List<RectangleResponse>;
                Assert.IsTrue(rc[0].matchingRectangles.Count == 1 && rc[1].matchingRectangles.Count == 3);
            }

        }
        [Test]
        public void SearchRectangles_ChkMatchingRectangles()
        {
            // Arrange
            List<Coordinate> coordinates = new List<Coordinate>
            {
                new Coordinate { X = 86, Y = 30 },
                new Coordinate { X = 79, Y = 95 }
            };

            // Act
            var result = _controller.Search(coordinates);
            var rst = result as OkObjectResult;

            if (rst != null)
            {
                var rc = rst.Value as List<RectangleResponse>;              
                Assert.IsTrue(checkID(rc));
            }

        }

        public bool? checkID(List<RectangleResponse> res)
        {
           
                if (res[0].matchingRectangles[0].Id == 1 && res[1].matchingRectangles[0].Id == 2 && res[1].matchingRectangles[1].Id == 60 && res[1].matchingRectangles[2].Id == 85) { return true; }else
                 return false;
           
        }
    }
}