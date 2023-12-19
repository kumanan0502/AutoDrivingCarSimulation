using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Application.Interfaces
{
    public  interface ISimulationService
    {
        Tuple<int,int,char> performCommand(Tuple<int,int,char> currentPosition, int x,int y,char moveCommand);
    }
}
