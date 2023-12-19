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

        public enum Commands
        {
            [Description("Rotates the car by 90 degrees the the right")]
            Right = 'R',
            [Description("Rotates the car by 90 degrees the the Left")]
            Left = 'L',
            [Description("Moves Forward by 1 grid point")]
            Forward = 'F'
        }

        public enum RestartOptions
        {
            [Description("[1] Start Over")]
            StartOver = 1,
            [Description("[2] Exit")]
            Exit = 2
        }


        #region [Error message const values]
        public const string ErrorMessage_Format_IsNull = "Format is null.";
        public const string ErrorMessage_Invalid_Format = "Invalid format Value.";
        public const string ErrorMessage_Simulation_XPosition_Is_Not_Int = "Simulation Field XPosition value is not a valid int.";
        public const string ErrorMessage_Simulation_XPosition_Is_Lesser_Than_Zero = "Simulation Field XPosition value is lesser than zero.";
        public const string ErrorMessage_Simulation_YPosition_Is_Not_Int = "Simulation Field YPosition value is not a valid int.";
        public const string ErrorMessage_Simulation_YPosition_Is_Lesser_Than_Zero = "Simulation Field YPosition value is lesser than zero.";

        public const string ErrorMessage_CarInitialPosition_IsNull = "Car Initial position is null.";
        public const string ErrorMessage_CarInitialPosition_Invalid = "Invalid Initial position Value.";
        public const string ErrorMessage_CarInitialDirection_IsNull = "Invalid Initial direction is null.";
        public const string ErrorMessage_CarInitialDirection_Invalid = "Invalid Initial position Value.";

        public const string Message_Selectoption_Description = "Please choose from the following options:";

        public const string Message_RestartOption1 = "[1] Start Over";

        public const string Message_RestartOption2 = "[2] Exit";

        public const string ErrorMessage_RestartOptionIsNull = "Restart option is null.";
        public const string ErrorMessage_RestartOptionIsNotValid = "Restart option is Invalid.";
        public const string ErrorMessage_RestartOptiont_Is_Not_Int = "Restart option is not a valid int.";
        public const string ErrorMessage_RestartOptiont_Invalid = "Restart select options.";

        public const string ErrorMessage_CarInitial_XPosition_Is_Not_Int = "Car Initial XPosition value is not a valid int.";
        public const string ErrorMessage_CarInitial_XPosition_Is_Greater_Than_Simulation_XPosition = "Car Initial XPosition value is greater than simulation Field XPosition.";
        public const string ErrorMessage_CarInitial_XPosition_Is_Lesser_Than_Zero = "Car Initial XPosition value is lesser than zero.";
        public const string ErrorMessage_CarInitial_YPosition_Is_Not_Int = "Car Initial YPosition format value is not a valid.";
        public const string ErrorMessage_CarInitial_YPosition_Is_Greater_Than_Simulation_YPosition = "Car Initial YPosition value is greater than simulation Field YPosition.";
        public const string ErrorMessage_CarInitial_YPosition_Is_Lesser_Than_Zero = "Car Initial YXPosition value is lesser than zero.";

        public const string ErrorMessage_CarSimulationCommand_IsNull = "Car simulation command is Null.";
        public const string ErrorMessage_CarSimulationCommand_Invalid = "Invalid Car simulation command List.";

        public const string Message_SimulationField_format = $"Please enter the width and height of the simulation maze in X Y  format :";
        public const string Message_Carin_Initial_Position = "Please enter initial position of the car in x y Direction format:";
        public const string Message_CarSimulation_Command = "Please enter the commands for car ";

        public const string Message_AfterSimulation_Finish_Result = "{0} {1} {2}";

        #endregion
    }
}
