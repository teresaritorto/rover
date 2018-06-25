using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Commands;
using Rover.Models;
using System.Collections.Generic;

namespace Rover.Test
{
    [TestClass]
    public class RobotCommandMapperTest
    {
        private RobotCommandMapper _instructionCommandMap;

        [TestInitialize]
        public void Setup()
        {
            _instructionCommandMap = new RobotCommandMapper();
        }
        
        private List<RobotCommand> GetCommands(Instruction instruction)
        {
            return _instructionCommandMap.GetCommands(instruction);
        }


        [TestMethod]
        public void MoveInstructionShouldMapMoveCommand()
        {
            //Setup & ACT
            var result = GetCommands(new Instruction("M"));

            //Assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] is MoveCommand);
        }

        [TestMethod]
        public void LeftInstructionShouldMapLeftCommand()
        {
            //Setup & ACT
            var result = GetCommands(new Instruction("L"));

            //Assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] is LeftCommand);
        }

        [TestMethod]
        public void RightInstructionShouldMapRightCommand()
        {
            //Setup & ACT
            var result = GetCommands(new Instruction("R"));

            //Assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] is RightCommand);
        }



        [TestMethod]
        public void InstructionShouldNotBeCaseSensitiveMapped()
        {
            //Setup & ACT
            var result = GetCommands(new Instruction("r"));

            //Assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] is RightCommand);
        }

        [TestMethod]
        public void MultipleInstructionsShouldBeMapped()
        {
            //Setup & ACT
            var result = GetCommands(new Instruction("rmlRrM"));

            //Assert
            Assert.IsTrue(result.Count == 6);
            Assert.IsTrue(result[0] is RightCommand);
            Assert.IsTrue(result[1] is MoveCommand);
            Assert.IsTrue(result[2] is LeftCommand);
            Assert.IsTrue(result[3] is RightCommand);
            Assert.IsTrue(result[4] is RightCommand);
            Assert.IsTrue(result[5] is MoveCommand);
        }
    }
}
