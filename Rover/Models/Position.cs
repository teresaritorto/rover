using Rover.Enums;

namespace Rover.Models
{
    /// <summary>
    /// Position relates to the X and Y values and Facing direction
    /// </summary>
    public class Position
    {
        public Position(int x, int y, Facing facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Facing Facing { get; set; }
    }
}
