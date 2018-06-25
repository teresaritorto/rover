using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Enums;
using Rover.Models;

namespace Rover.Test.Models
{
    [TestClass]
    public class InstructionTest
    {
        [TestMethod]
        public void CanInitializeAValidMoveInstruction()
        {
            //Setup
            var instruction = new Instruction("M");

            //Assert
            Assert.AreEqual(instruction.Commands.Count, 1);
            Assert.IsTrue(instruction.Commands[0] is CommandType.M);
        }

        [TestMethod]
        public void CanInitializeAValidLeftInstruction()
        {
            //Setup
            var instruction = new Instruction("L");

            //Assert
            Assert.AreEqual(instruction.Commands.Count, 1);
            Assert.IsTrue(instruction.Commands[0] is CommandType.L);
        }

        [TestMethod]
        public void CanInitializeAValidRightInstruction()
        {
            //Setup
            var instruction = new Instruction("R");

            //Assert
            Assert.AreEqual(instruction.Commands.Count, 1);
            Assert.IsTrue(instruction.Commands[0] is CommandType.R);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotInitializeAnEmptyInstruction()
        {
            //Setup & Assert
            var instruction = new Instruction("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotInitializeAnUnknownInstruction()
        {
            //Setup & Assert
            var instruction = new Instruction("Not a valid instruction");
        }

        public void CanInitializeValidMultipleInstructions()
        {
            //Setup
            var instruction = new Instruction("LMRL");

            //Assert
            Assert.AreEqual(instruction.Commands.Count, 4);
            Assert.IsTrue(instruction.Commands[0] is CommandType.L);
            Assert.IsTrue(instruction.Commands[1] is CommandType.M);
            Assert.IsTrue(instruction.Commands[2] is CommandType.R);
            Assert.IsTrue(instruction.Commands[3] is CommandType.L);
        }
    }
}
