namespace Rover.Models
{
    /// <summary>
    /// Defines the boundary of the location, such that a maximum x and maximum y value are configured
    /// and this boundary can be queried as within range by passing in x & y values
    /// Note: 0 is assumed as the min x & y values.
    /// </summary>
    public class Bounds
    {
        private readonly int _maxY;
        private readonly int _maxX;

        public Bounds(int x, int y)
        {
            _maxX = x - 1;
            _maxY = y - 1;
        }

        /// <summary>
        /// Checks that the x and y parameters are
        /// within the bound of the max x and y set
        /// and must be greater than zero
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns></returns>
        public bool IsInBounds(int x, int y)
        {
            return x <= _maxX && x >= 0
                   && y <= _maxY && y >= 0;
        }
    }
}
