using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Commands;
using Rover.Enums;
using Rover.Models;

namespace Rover.Test.Commands
{
    [TestClass]
    public class RightCommandTest
    {
        private RightCommand _rightCommand;
        private Robot _robot;
        private const int X = 2;
        private const int Y = 3;

        [TestInitialize]
        public void Setup()
        {
            _rightCommand = new RightCommand();
            _robot = new Robot(X, Y)
            {
                CurrentPosition = new Position(X, Y, Facing.N)
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanNotExecutePlaceCommandWithNullRobot()
        {
            //Act & Assert
            _rightCommand.Execute(null);
        }

        [TestMethod]
        public void CanExecuteRightCommandFacingNorth()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.N;

            //Act
            _rightCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.E);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }

        [TestMethod]
        public void CanExecuteRightCommandFacingSouth()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.S;

            //Act
            _rightCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.W);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }

        [TestMethod]
        public void CanExecuteRightCommandFacingEast()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.E;

            //Act
            _rightCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.S);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }

        [TestMethod]
        public void CanExecuteRightCommandFacingWest()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.W;

            //Act
            _rightCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.N);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }
    }
}
