using Rover.Enums;
using Rover.Models;

namespace Rover
{
    /// <summary>
    /// Responsible for initializing a robot, taking a valid instruction string, parsing that instruction to a robot command 
    /// and executing the robot command, returning an execution response
    /// </summary>
    public class RobotController
    {
        private readonly RobotCommandMapper _robotInstructionCommandMapper = new RobotCommandMapper();

        /// <summary>
        /// Initialise a robot controller for a defined boundary size
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public RobotController(int x, int y)
        {
            Robot = new Robot(x, y);
        }

        public Robot Robot { get; private set; }

        public void PlaceRover(int x, int y, Facing direction)
        {
            Robot.CurrentPosition = new Position(x, y, direction);
        }

        /// <summary>
        /// Execute a valid command to the robot
        /// </summary>
        /// <param name="instructionText"></param>
        /// <returns></returns>
        public string ExecuteCommandsFromInstructions(string instructionText)
        {
            var instruction = instructionText.ToInstruction();
            var commands = _robotInstructionCommandMapper.GetCommands(instruction);

            foreach (var command in commands)
            {
                command.Execute(Robot);
            }

            return Robot.ToString();
        }
    }
}
