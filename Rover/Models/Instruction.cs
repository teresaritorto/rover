using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Rover.Enums;

namespace Rover.Models
{
    /// <summary>
    /// Instruction initialized with a valid instruction string
    /// </summary>
    public class Instruction
    {
        public List<CommandType> Commands { get; private set; }
        public Instruction() { }

        /// <summary>
        /// Initialization only possible with a valid regex matched instruction string which initializes a list of commands
        /// </summary>
        /// <param name="instructionText">instruction string</param>
        public Instruction(string instructionText)
        {
            if (string.IsNullOrEmpty(instructionText) || !Regex.Match(instructionText, @"(m+)?(l+)?(r+)?$", RegexOptions.IgnoreCase).Success)
                throw new ArgumentException("Invalid instruction text");

            var commandStrings = instructionText.ToCharArray();
            Commands = commandStrings.Select(array => (CommandType)Enum.Parse(typeof(CommandType), array.ToString(), true)).ToList();
        }
    }
}
