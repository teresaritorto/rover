using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Commands;
using Rover.Enums;
using Rover.Models;

namespace Rover.Test.Commands
{
    [TestClass]
    public class MoveCommandTest
    {
        private MoveCommand _moveCommand;
        private Robot _robot;
        private const int X = 2;
        private const int Y = 3;

        [TestInitialize]
        public void Setup()
        {
            _moveCommand = new MoveCommand();
            _robot = new Robot(5, 5)
            {
                CurrentPosition = new Position(X, Y, Facing.N)
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanNotExecutePlaceCommandWithNullRobot()
        {
            _moveCommand.Execute(null);
        }

        [TestMethod]
        public void CanExecuteMoveCommandFacingNorth()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.N;

            //Act
            _moveCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.N);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y + 1);
        }

        [TestMethod]
        public void CanExecuteMoveCommandFacingSouth()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.S;

            //Act
            _moveCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.S);
            Assert.AreEqual(_robot.CurrentPosition.X, X);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y - 1);
        }

        [TestMethod]
        public void CanExecuteMoveCommandFacingEast()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.E;

            //Act
            _moveCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.E);
            Assert.AreEqual(_robot.CurrentPosition.X, X + 1);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }

        [TestMethod]
        public void CanExecuteMoveCommandFacingWest()
        {
            //Setup
            _robot.CurrentPosition.Facing = Facing.W;

            //Act
            _moveCommand.Execute(_robot);

            //Assert
            Assert.AreEqual(_robot.CurrentPosition.Facing, Facing.W);
            Assert.AreEqual(_robot.CurrentPosition.X, X - 1);
            Assert.AreEqual(_robot.CurrentPosition.Y, Y);
        }
    }
}
