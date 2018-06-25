using Rover.Enums;

namespace Rover.Models
{
    /// <summary>
    /// Robot has a concept of its current position and a location with defined bounds
    /// </summary>
    public class Robot
    {
        public Position CurrentPosition { get; set; }
        public Plateau Plateau { get; }

        public override string ToString()
        {
            return $"{CurrentPosition.X} {CurrentPosition.Y} {CurrentPosition.Facing}";
        }

        /// <summary>
        /// Initialize with position and a boundary
        /// </summary>
        public Robot(int x, int y)
        {
            //defaults
            Plateau = new Plateau(x, y);
            CurrentPosition = new Position(0, 0, Facing.N);
        }
    }
}
