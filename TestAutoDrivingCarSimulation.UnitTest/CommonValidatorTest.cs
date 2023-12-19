using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Domain.Models;
using AutoDrivingCarSimulation.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TestAutoDrivingCarSimulation.UnitTest
{
    public class CommonValidatorTest
    {
        public ICommonValidator _CommonValidator;
        public SimulationMatrix simulationField;

        [SetUp]
        public void Setup()
        {
            _CommonValidator = new CommonValidator();
            simulationField = new SimulationMatrix();
        }

        [Test]
        [TestCase("")]
        [TestCase("x x")]
        [TestCase("x 10")]
        [TestCase("10 x")]
        [TestCase("-5 -5")]
        [TestCase("10 10 10")]
        [TestCase("0 0")]
        [TestCase("1 0")]
        [TestCase("0 1")]
        public void Test_SimulationField_Fail(string strSimulationField)
        {
            bool isValid = _CommonValidator.SimulationFieldValidate(strSimulationField, ref simulationField);

            Assert.AreEqual(false, isValid);
        }

        [Test]
        [TestCase("10 10")]
        [TestCase("5 10")]
        [TestCase("10 5")]
        [TestCase("2 12")]
        [TestCase("1 1")]
        public void Test_SimulationField_Success(string strSimulationField)
        {

            bool isValid = _CommonValidator.SimulationFieldValidate(strSimulationField, ref simulationField);

            Assert.AreEqual(true, isValid);
        }

        [Test]
        [TestCase(10, 10, "")]
        [TestCase(10, 10, " ")]
        [TestCase(10, 10, "a b ")]
        [TestCase(10, 10, "1 1 ")]
        [TestCase(10, 10, "1 1 a")]
        [TestCase(10, 10, "1 1 5")]
        [TestCase(10, 10, "-5 -5 5")]
        [TestCase(10, 10, "-5 -5 N")]
        [TestCase(10, 10, "15 15 N")]
        public void Test_CarInitialPosition_Fail(int xPosition, int yPosition, string strInitialPosition)
        {
            Tuple<int, int, char> carPosition = new Tuple<int, int, char>(xPosition, yPosition, 'N');
            simulationField.xAxis = xPosition;
            simulationField.yAxis = yPosition;
            
            bool isValid = _CommonValidator.CarInititalPositionValidate(strInitialPosition, simulationField, ref carPosition);

            Assert.AreEqual(false, isValid);
        }
        [Test]
        [TestCase(10, 10, "1 1 N")]
        [TestCase(10, 10, "7 8 E")]
        [TestCase(10, 10, "8 4 W")]
        [TestCase(10, 10, "5 5 S")]
        public void Test_CarInitialPosition_Success(int xPosition, int yPosition, string strInitialPosition)
        {

            Tuple<int, int, char> carPosition = new Tuple<int, int, char>(xPosition, yPosition, 'N');
            simulationField.xAxis = xPosition;
            simulationField.yAxis = yPosition;

            bool isValid = _CommonValidator.CarInititalPositionValidate(strInitialPosition, simulationField, ref carPosition);

            Assert.AreEqual(true, isValid);
        }

        [Test]
        [TestCase("")]
        [TestCase("XXX")]
        [TestCase("RL5")]
        [TestCase("-1")]
        public void Test_CarSimulationCommand_Fail(string strCarSimulationCommand)
        {
            char[] commanArray = new char[1000];
            bool isValid = _CommonValidator.CarSimulationCommandValidate(strCarSimulationCommand, ref commanArray);

            Assert.AreEqual(false, isValid);
        }

        [Test]
        [TestCase("R")]
        [TestCase("L")]
        [TestCase("F")]
        [TestCase("LF")]
        [TestCase("LFR")]
        [TestCase("LFRLFR")]
        [TestCase("LFRLFRFFFF")]
        public void Test_CarSimulationCommand_Success(string strCarSimulationCommand)
        {
            char[] commanArray = new char[1000];
            bool isValid = _CommonValidator.CarSimulationCommandValidate(strCarSimulationCommand, ref commanArray);

            Assert.AreEqual(true, isValid);
        }
    }
}
