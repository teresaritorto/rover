using Rover.Enums;
using Rover.Models;
using System.Collections.Generic;

namespace Rover.Commands
{
    /// <summary>
    /// Turn the robot to the left, relative to its current position by setting its new facing position
    /// </summary>
    public class LeftCommand : RobotCommand
    {
        private Dictionary<Facing, Facing> LeftMappings = new Dictionary<Facing, Facing>();

        public LeftCommand() : base()
        {
            LeftMappings.Add(Facing.E, Facing.N);
            LeftMappings.Add(Facing.W, Facing.S);
            LeftMappings.Add(Facing.S, Facing.E);
            LeftMappings.Add(Facing.N, Facing.W);
        }
        
        public override void Execute(Robot robot)
        {
            base.Execute(robot);
            robot.CurrentPosition.Facing = LeftMappings[robot.CurrentPosition.Facing];
        }
    }
}
