using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Models;

namespace Rover.Test.Models
{
    [TestClass]
    public class BoundsTest
    {
        private Bounds _boundary;

        [TestInitialize]
        public void Setup()
        {
            _boundary = new Bounds(5, 5);
        }

        [TestMethod]
        public void TestBoundaryXIsNotInBounds()
        {
            //Act
            var result = _boundary.IsInBounds(6, 2);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBoundaryYIsNotInBounds()
        {
            //Act
            var result = _boundary.IsInBounds(2, 5);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBoundaryMaxXyIsNotInBounds()
        {
            //Act
            var result = _boundary.IsInBounds(10, 10);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBoundaryMinXyIsNotInBounds()
        {
            //Act
            var result = _boundary.IsInBounds(-1, -1);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBoundaryXyIsInBounds()
        {
            //Act
            var result = _boundary.IsInBounds(4, 4);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
