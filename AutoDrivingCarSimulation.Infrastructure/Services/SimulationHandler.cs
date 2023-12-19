using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Infrastructure.Services
{
    public class SimulationHandler : ISimulationHandler
    {
        private ISimulationService _simulationService;

        public SimulationHandler(ISimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        public Tuple<int, int, char> PerformSimulation(Tuple<int, int, char> currentPoistion, SimulationMatrix field, char[] command)
        {
            int xOut = currentPoistion.Item1;
            int yOut = currentPoistion.Item2;
            char postionOut = currentPoistion.Item3;

            foreach (var singleCommand in command)
            {
                var singleCommandResult = _simulationService.PerformCommand(new Tuple<int, int, char>(xOut, yOut, postionOut),
                                            field.xAxis, field.yAxis, singleCommand);
                if (singleCommandResult != null)
                {
                    xOut = singleCommandResult.Item1;
                    yOut = singleCommandResult.Item2;
                    postionOut = singleCommandResult.Item3;
                }
            }

            return new Tuple<int,int,char>(xOut,yOut, postionOut); 
        }
    }
}
