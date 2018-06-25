using Rover.Enums;
using Rover.Models;
using System.Collections.Generic;

namespace Rover.Commands
{
    /// <summary>
    /// Turn the robot to the right, relative to its current position by setting its new facing position
    /// </summary>
    public class RightCommand : RobotCommand
    {
        private Dictionary<Facing, Facing> RightMappings = new Dictionary<Facing, Facing>();

        public RightCommand() : base()
        {
            RightMappings.Add(Facing.E, Facing.S);
            RightMappings.Add(Facing.W, Facing.N);
            RightMappings.Add(Facing.S, Facing.W);
            RightMappings.Add(Facing.N, Facing.E);
        }

        public override void Execute(Robot robot)
        {
            base.Execute(robot);
            robot.CurrentPosition.Facing = RightMappings[robot.CurrentPosition.Facing];
        }
    }
}
