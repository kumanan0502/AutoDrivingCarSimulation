using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Domain.Helpers;
using AutoDrivingCarSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation
{
    public class AutoDrivingSimulation
    {
        private readonly ICommonValidator _commonValidator;
        private readonly ISimulationHandler _simulationHandler;
        public AutoDrivingSimulation(ICommonValidator commonValidator, ISimulationHandler simulationHandler)
        {
            _commonValidator = commonValidator;
            _simulationHandler = simulationHandler;
        }

        public void start()
        {
            int restartOption = 1;
            while (restartOption != (int)SimulaterHelper.RestartOptions.Exit)
            {

                Console.WriteLine("\n");
                Console.WriteLine(SimulaterHelper.Message_SimulationField_format);

                string strSimulationField = Console.ReadLine();

                SimulationMatrix simulationField = new SimulationMatrix();
                while (!_commonValidator.SimulationFieldValidate(strSimulationField, ref simulationField))
                {
                    Console.WriteLine(SimulaterHelper.Message_SimulationField_format);
                    strSimulationField = Console.ReadLine();
                }

                Console.WriteLine(string.Format(SimulaterHelper.Message_Carin_Initial_Position));
                string InitialPosition = Console.ReadLine();
                Tuple<int, int, char> currenctPosition = new Tuple<int, int, char>(0, 0, 'N');

                while (!_commonValidator.CarInititalPositionValidate(InitialPosition, simulationField, ref currenctPosition))
                {
                    Console.WriteLine(string.Format(SimulaterHelper.Message_Carin_Initial_Position));
                    InitialPosition = Console.ReadLine();
                }

                Console.WriteLine(string.Format(SimulaterHelper.Message_CarSimulation_Command));
                string strCarSimulationCommand = Console.ReadLine();
                char[] commandArray = new char[1000];

                while (!_commonValidator.CarSimulationCommandValidate(strCarSimulationCommand, ref commandArray))
                {
                    Console.WriteLine(string.Format(SimulaterHelper.Message_CarSimulation_Command));
                    strCarSimulationCommand = Console.ReadLine();
                }

                var performSimulation = _simulationHandler.PerformSimulation(currenctPosition, simulationField, commandArray);

                Console.WriteLine(string.Format(SimulaterHelper.Message_AfterSimulation_Finish_Result, performSimulation.Item1, performSimulation.Item2, performSimulation.Item3));

                Console.WriteLine("\n");
                Console.WriteLine(SimulaterHelper.Message_Selectoption_Description);
                Console.WriteLine(SimulaterHelper.Message_RestartOption1);
                Console.WriteLine(SimulaterHelper.Message_RestartOption2);

                string strRestartOption = Console.ReadLine();

                while (!_commonValidator.RestartOptionValidate(strRestartOption, ref restartOption))
                {
                    Console.WriteLine(SimulaterHelper.Message_Selectoption_Description);
                    Console.WriteLine(SimulaterHelper.Message_RestartOption1);
                    Console.WriteLine(SimulaterHelper.Message_RestartOption2);

                    strRestartOption = Console.ReadLine();
                }

            }

        }
    }
}
