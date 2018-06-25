using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Commands;
using Rover.Enums;
using Rover.Models;

namespace Rover.Test.Commands
{
    [TestClass]
    public class LeftCommandTest
    {
        private LeftCommand _leftCommand;
        private Robot _robot;
        private const int X = 2;
        private const int Y = 3;

        [TestInitialize]
        public void Setup()
        {
            _leftCommand = new LeftCommand();
            _robot = new Robot(X, Y)
            {
                CurrentPosition = new Position(X, Y, Facing.N)
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanNotExecutePlaceCommandWithNullRobot()
        {
            _leftCommand.Execute(null);
        }

        [TestMethod]
        public void CanExecuteLeftCommandFacingNorth()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.N;

            //Act
            _leftCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.W);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }

        [TestMethod]
        public void CanExecuteLeftCommandFacingSouth()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.S;

            //Act
            _leftCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.E);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }

        [TestMethod]
        public void CanExecuteLeftCommandFacingEast()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.E;

            //Act
            _leftCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.N);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }

        [TestMethod]
        public void CanExecuteLeftCommandFacingWest()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.W;

            //Act
            _leftCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.S);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }
    }
}
