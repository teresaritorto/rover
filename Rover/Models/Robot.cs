using Rover.Enums;

namespace Rover.Models
{
    /// <summary>
    /// Robot has a concept of its current position and a location with defined bounds
    /// </summary>
    public class Robot
    {
        public Position CurrentPosition { get; set; }
        public Bounds Boundary { get; }

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
            Boundary = new Bounds(x, y);
            CurrentPosition = new Position(0, 0, Facing.N);
        }
    }
}
