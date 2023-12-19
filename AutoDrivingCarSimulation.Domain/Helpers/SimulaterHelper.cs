using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Domain.Helpers
{
    public static class SimulaterHelper
    {
        public enum Direction
        {
            [Description("North")]
            North = 'N',
            [Description("East")]
            East = 'E',
            [Description("South")]
            South = 'S',
            [Description("West")]
            West = 'W'
        }
    }
}
