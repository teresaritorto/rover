using System;
using System.Collections.Generic;
using Rover.Commands;
using Rover.Enums;
using Rover.Models;

namespace Rover
{
    /// <summary>
    /// Instruction to robot command mapper
    /// </summary>
    public class RobotCommandMapper
    {
        private readonly Dictionary<CommandType, Func<RobotCommand>> _robotInstructionCommandMap
            = new Dictionary<CommandType, Func<RobotCommand>>();

        public RobotCommandMapper()
        {
            MapData(_robotInstructionCommandMap);
        }

        /// <summary>
        /// For a given instruction with commands, apply the instruction 
        /// command mappings for each
        /// </summary>
        /// <param name="instruction">Instruction</param>
        /// <returns></returns>
        public List<RobotCommand> GetCommands(Instruction instruction)
        {
            if (instruction == null)
                throw new NotImplementedException("Unsupported Robot Instruction");

            var robotCommands = new List<RobotCommand>();

            foreach (var command in instruction.Commands)
            {
                robotCommands.Add(GetCommand(command));
            }

            return robotCommands;
        }
        /// <summary>
        /// Use the command type to map to the correct robot command
        /// </summary>
        /// <param name="command">Command Type</param>
        public RobotCommand GetCommand(CommandType command)
        {
            //ensure its an instruction we have mapped to a command
            if (!_robotInstructionCommandMap.ContainsKey(command))
            {
                throw new NotImplementedException("Unsupported Robot Instruction");
            }

            return _robotInstructionCommandMap[command].Invoke();
        }

        /// <summary>
        /// Map Instruction data to a Command
        /// These are the commands the robot can perform based on the instruction type
        /// </summary>
        /// <param name="map">Dictionary of mapped commands</param>
        private void MapData(IDictionary<CommandType, Func<RobotCommand>> map)
        {
            map.Add(CommandType.L, () => new LeftCommand());
            map.Add(CommandType.R, () => new RightCommand());
            map.Add(CommandType.M, () => new MoveCommand());
        }
    }
}
