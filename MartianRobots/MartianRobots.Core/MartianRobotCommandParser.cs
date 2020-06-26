using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Core
{
    public static class MartianRobotCommandParser
    {
        public static IEnumerable<IMartianRobotAction> Parse(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                yield break;
            }

            if (command.Length > 100)
            {
                throw new ArgumentException(nameof(command));
            }


        }
    }
}
