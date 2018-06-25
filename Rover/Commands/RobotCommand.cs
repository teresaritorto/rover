using System;
using Rover.Models;

namespace Rover.Commands
{
    /// <summary>
    /// abstract robot command defining the base initialization and implementation to execute
    /// </summary>
    public abstract class RobotCommand
    {
        protected RobotCommand(){}

        public virtual void Execute(Robot robot)
        {
            if (robot == null)
                throw new ArgumentNullException("Robot required to execute command");
        }
    }
}
