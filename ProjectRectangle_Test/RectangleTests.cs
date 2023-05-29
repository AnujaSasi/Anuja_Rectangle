using NUnit.Framework;

namespace ProjectRectangle_Test
{
    [TestFixture]
    public class RectangleControllerTests
    {
        private RectangleClassController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller or any necessary dependencies here
            // For example, you can create an instance of the controller and set up dependencies using a mocking framework like Moq
            // If you have a dependency on the DbContext, you can use an in-memory database for testing purposes
            _controller = new RectangleClassController();
            // Set up any necessary dependencies or context
        }

        [Test]
        public void SearchRectangles_ReturnsCorrectResult()
        {
            // Arrange
            var coordinates = new Coordinate[]
            {
            new Coordinate { X = 5, Y = 10 },
            new Coordinate { X = 15, Y = 20 }
            };

            // Act
            var result = _controller.SearchRectangles(coordinates);

            // Assert
            Assert.IsNotNull(result);
            // Add additional assertions to verify the correctness of the result
        }
    }
}




