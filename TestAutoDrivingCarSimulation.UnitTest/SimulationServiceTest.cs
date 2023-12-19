using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Infrastructure.Services;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TestAutoDrivingCarSimulation.UnitTest
{
    public class SimulationServiceTest
    {
        public ISimulationService _simulationService;
        int x;
        int y;

        [SetUp]
        public void Setup()
        {
            _simulationService = new SimulationService();
            x = 9; y = 9;
        }

        [Test]
        [TestCase(1, 1, 'N', 1, 2, 'N')]
        [TestCase(1, 1, 'E', 2, 1, 'E')]
        [TestCase(1, 1, 'S', 1, 0, 'S')]
        [TestCase(1, 1, 'W', 0, 1, 'W')]
        public async Task Test_performCommand_Success_MoveForwad_AllPossibleDirection_ReturnCurrent_Position(int xInput, int yInput, char positionInput, int xExpected, int yExpected, char postionExpected)
        {
            Tuple<int, int, char> _currentPosition = new Tuple<int, int, char>(xInput, yInput, positionInput);

            var moveCommand = 'F';

            var result = await _simulationService.performCommand(_currentPosition, x, y, moveCommand);

            Assert.AreEqual(xExpected, result.Item1);
            Assert.AreEqual(yExpected, result.Item2);
            Assert.AreEqual(postionExpected, result.Item3);

        }


     

        [Test]
        [TestCase(1, 9, 'N', 1, 9, 'N')]
        [TestCase(9, 1, 'E', 9, 1, 'E')]
        [TestCase(9, 0, 'S', 9, 0, 'S')]
        [TestCase(0, 9, 'W', 0, 9, 'W')]
        public async Task Test_performCommand_CommandIgnored_MoveForwad_AllPossibleDirections_ReturnCurrent_Position(int xInput, int yInput, char positionInput, int xExpected, int yExpected, char postionExpected)
        {
            Tuple<int, int, char> _currentPosition = new Tuple<int, int, char>(xInput, yInput, positionInput);

            var moveCommand = 'F';

            var result = await _simulationService.performCommand(_currentPosition, x, y, moveCommand);

            Assert.AreEqual(xExpected, result.Item1);
            Assert.AreEqual(yExpected, result.Item2);
            Assert.AreEqual(postionExpected, result.Item3);

        }


       
        [Test]
        [TestCase('N','E')]
        [TestCase('E', 'S')]
        [TestCase('S', 'W')]
        [TestCase('W', 'N')]
        public async Task Test_performCommand_Sucess_TurnRight_AllPossibleOptions_ReturnCurrent_Position(char positionInput, char postionExpected)
        {
            Tuple<int, int, char> _currentPosition = new Tuple<int, int, char>(1, 1, positionInput);

            var moveCommand = 'R';

            var result = await _simulationService.performCommand(_currentPosition, x, y, moveCommand);

            
            Assert.AreEqual(postionExpected, result.Item3);

        }

        [Test]
        [TestCase('N', 'W')]
        [TestCase('W', 'S')]
        [TestCase('S', 'E')]
        [TestCase('E', 'N')]
        public async Task Test_performCommand_Sucess_TurnLeft_AllPossibleOptions_ReturnCurrent_Position(char positionInput, char postionExpected)
        {
            Tuple<int, int, char> _currentPosition = new Tuple<int, int, char>(1, 1, positionInput);

            var moveCommand = 'L';

            var result = await _simulationService.performCommand(_currentPosition, x, y, moveCommand);

        
            Assert.AreEqual(postionExpected, result.Item3);

        }
    }
}
