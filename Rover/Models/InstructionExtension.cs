namespace Rover.Models
{
    public static class InstructionExtension
    {
        /// <summary>
        /// Get an Instruction object from the input text string
        /// </summary>
        /// <param name="instructionText">instruction string</param>
        /// <returns>Instruction</returns>
        public static Instruction ToInstruction(this string instructionText)
        {
            return new Instruction(instructionText);
        }
    }
}
