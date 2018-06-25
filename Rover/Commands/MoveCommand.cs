using System;
using Rover.Enums;
using Rover.Models;

namespace Rover.Commands
{
    /// <summary>
    /// Move command responsible for increasing the x or y position of the robot relative to its facing position.
    /// It will only apply the move if it is a valid new position (i.e. within the bounds of the location)
    /// </summary>
    public class MoveCommand : RobotCommand
    {
        public MoveCommand() : base() { }

        public override void Execute(Robot robot)
        {
            base.Execute(robot);

            int newX;
            int newY;

            switch (robot.CurrentPosition.Facing)
            {
                case Facing.E:
                    newX = robot.CurrentPosition.X + 1;
                    newY = robot.CurrentPosition.Y;
                    break;
                case Facing.N:
                    newX = robot.CurrentPosition.X;
                    newY = robot.CurrentPosition.Y + 1;
                    break;
                case Facing.W:
                    newX = robot.CurrentPosition.X - 1;
                    newY = robot.CurrentPosition.Y;
                    break;
                case Facing.S:
                    newX = robot.CurrentPosition.X;
                    newY = robot.CurrentPosition.Y - 1;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown Facing: {robot.CurrentPosition.Facing}");
            }

            //ignore move if it has reached the boundary
            if (robot.Boundary.IsInBounds(newX, newY))
            {
                robot.CurrentPosition.X = newX;
                robot.CurrentPosition.Y = newY;
            }
        }
    }
}
