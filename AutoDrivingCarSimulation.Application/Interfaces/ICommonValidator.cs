using AutoDrivingCarSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Application.Interfaces
{
    public interface ICommonValidator
    {
        bool SimulationFieldValidate(string format, ref SimulationMatrix simulationField);

        bool CarInititalPositionValidate(string input, SimulationMatrix simulationMatrix, ref Tuple<int, int, char> carPosition);

        bool CarSimulationCommandValidate(string strCarSimulationCommand, ref char[] commandArray);
    }
}
