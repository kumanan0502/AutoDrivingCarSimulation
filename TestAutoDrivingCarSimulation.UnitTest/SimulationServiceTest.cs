using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Infrastructure.Services;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutoDrivingCarSimulation.UnitTest
{
    public class SimulationServiceTest
    {
        public ISimulationService _simulationService;

        [SetUp]
        public void Setup()
        {
            _simulationService = new SimulationService();
        }

        [Test]
        public async Task Test_performCommand_Success_ReturnCurrent_Position()
        {
            Tuple<int, int, char> _currentPosition = new Tuple<int, int, char>(1, 1, 'N');
            int x = 9;
            int y = 9;
            var moveCommand = 'F';

            Tuple<int, int, char> _expectPositon = new Tuple<int, int, char>(2, 1,'N');

            var result = await _simulationService.performCommand(_currentPosition, x, y, moveCommand);

            Assert.AreEqual(_expectPositon.Item1, result.Item1);
            Assert.AreEqual(_expectPositon.Item2, result.Item2);
            Assert.AreEqual(_expectPositon.Item3, result.Item3);

        }
    }
}
