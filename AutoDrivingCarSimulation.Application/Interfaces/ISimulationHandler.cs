using AutoDrivingCarSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Application.Interfaces
{
    public interface ISimulationHandler
    {
        Tuple<int, int, char> PerformSimulation(Tuple<int, int, char> currentPoistion, SimulationMatrix field, char[] command);
    }
}
