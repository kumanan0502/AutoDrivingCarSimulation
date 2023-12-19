using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Domain.Helpers;
using AutoDrivingCarSimulation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Infrastructure.Services
{
    public class CommonValidator : ICommonValidator
    {
        public bool SimulationFieldValidate(string format, ref SimulationMatrix simulationField)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(format))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_Format_IsNull);
                return false;
            }

            string[] strFormatlist = format.Split(' ');

            if (strFormatlist.Length != 2)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_Invalid_Format);
                return false;
            }

            if (!int.TryParse(strFormatlist[0], out int xPosition))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_Simulation_XPosition_Is_Not_Int);
                isValid = false;
            }
            else if (0 >= xPosition)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_Simulation_XPosition_Is_Lesser_Than_Zero);
                isValid = false;
            }

            if (!int.TryParse(strFormatlist[1], out int yPosition))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_Simulation_YPosition_Is_Not_Int);
                isValid = false;
            }
            else if (0 >= yPosition)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_Simulation_YPosition_Is_Lesser_Than_Zero);
                isValid = false;
            }

            if (isValid)
            {
                simulationField.xAxis = xPosition -1;
                simulationField.yAxis = yPosition -1;
            }

            return isValid;
        }

        public bool CarInititalPositionValidate(string input, SimulationMatrix simulationMatrix, ref Tuple<int,int,char> carPosition)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitialPosition_IsNull);
                return false;
            }

            string[] list = input.Split(' ');

            if (list.Length != 3)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitialPosition_Invalid);
                return false;
            }

            if (!int.TryParse(list[0], out int xPosition))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitial_XPosition_Is_Not_Int);
                isValid = false;
            }
            else if (simulationMatrix.xAxis < xPosition)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitial_XPosition_Is_Greater_Than_Simulation_XPosition);
                isValid = false;
            }
            else if (0 > xPosition)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitial_XPosition_Is_Lesser_Than_Zero);
                isValid = false;
            }

            if (!int.TryParse(list[1], out int yPosition))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitial_YPosition_Is_Not_Int);
                isValid = false;
            }
            else if (simulationMatrix.yAxis < yPosition)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitial_YPosition_Is_Greater_Than_Simulation_YPosition);
                isValid = false;
            }
            else if (0 > yPosition)
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitial_YPosition_Is_Lesser_Than_Zero);
                isValid = false;
            }

            if (string.IsNullOrEmpty(list[2]))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitialDirection_IsNull);
                isValid = false;
            }
            else if (!Enum.IsDefined(typeof(SimulaterHelper.Direction), (int)list[2][0]))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarInitialDirection_Invalid);
                isValid = false;
            }

            if (isValid)
            {
                
                carPosition = new Tuple<int, int, char>(xPosition, yPosition, list[2][0]);

                return isValid;

            }

            return isValid;
        }

        public bool CarSimulationCommandValidate(string strCarSimulationCommand, ref char[] commandArray)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(strCarSimulationCommand))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarSimulationCommand_IsNull);
                return false;
            }

            char[] carSimulationCommandList = strCarSimulationCommand.ToCharArray();

            if (!carSimulationCommandList.All(c => Enum.IsDefined(typeof(SimulaterHelper.Commands), (int)c)))
            {
                Console.WriteLine(SimulaterHelper.ErrorMessage_CarSimulationCommand_Invalid);
                return false;
            }

            commandArray = carSimulationCommandList;

            return isValid;
        }
    }
}
