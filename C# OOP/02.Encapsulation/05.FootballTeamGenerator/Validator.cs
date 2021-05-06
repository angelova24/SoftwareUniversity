using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfNumberNotInRange(int min, int max, int value, string exeptionMessage)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(exeptionMessage);
            }
        }
    }
}
