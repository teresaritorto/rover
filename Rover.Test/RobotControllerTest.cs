using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Enums;

namespace Rover.Test
{
    [TestClass]
    public class RobotControllerTest
    {
        private RobotController _robotController;

        [TestInitialize]
        public void Setup()
        {
            _robotController = new RobotController(5, 5);
        }

        [TestMethod]
        public void EnsureRobotDoesNotFallOutOfBounds()
        {
            //Act
            _robotController.PlaceRover(0, 0, Facing.N);
            _robotController.ExecuteCommandsFromInstructions("M");
            _robotController.ExecuteCommandsFromInstructions("M");
            _robotController.ExecuteCommandsFromInstructions("M");
            var lastSuccessfulResult =_robotController.ExecuteCommandsFromInstructions("M");

            var lastValidPosition = _robotController.Robot.CurrentPosition;

            //Apply invalid move command
            var lastResult = _robotController.ExecuteCommandsFromInstructions("M");

            //Assert
            Assert.AreEqual(_robotController.Robot.CurrentPosition.Facing, lastValidPosition.Facing);
            Assert.AreEqual(_robotController.Robot.CurrentPosition.X, lastValidPosition.X);
            Assert.AreEqual(_robotController.Robot.CurrentPosition.Y, lastValidPosition.Y);
        }

        [TestMethod]
        public void EnsureRobotExecutesMultipleInstructions()
        {
            //Act
            _robotController.PlaceRover(1, 2, Facing.E);
            _robotController.ExecuteCommandsFromInstructions("M");
            _robotController.ExecuteCommandsFromInstructions("M");
            _robotController.ExecuteCommandsFromInstructions("L");
            var result = _robotController.ExecuteCommandsFromInstructions("M");

            //Assert
            Assert.AreEqual(result, $"{_robotController.Robot.CurrentPosition.X} {_robotController.Robot.CurrentPosition.Y} {_robotController.Robot.CurrentPosition.Facing}");
            Assert.AreEqual(_robotController.Robot.CurrentPosition.Facing, Facing.N);
            Assert.AreEqual(_robotController.Robot.CurrentPosition.X, 3);
            Assert.AreEqual(_robotController.Robot.CurrentPosition.Y, 3);
        }
    }
}
