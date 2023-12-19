using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Domain.Models;
using AutoDrivingCarSimulation.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TestAutoDrivingCarSimulation.UnitTest
{
    public class SimulationHandlerTest
    {

        private IServiceProvider _serviceProvider;

        [SetUp]
        public void SetUp()
        {
            _serviceProvider = new ServiceCollection()
                .AddScoped<ISimulationHandler, SimulationHandler>()
                .AddTransient<ISimulationService, SimulationService>()
                .BuildServiceProvider();
        }

        [Test]
        [TestCase(1, 1, 'N', 9, 9, "FF", 1, 3, 'N')]
        [TestCase(1, 1, 'N', 9, 9, "FFRFLFR", 2, 4, 'E')]
        [TestCase(4, 4, 'N', 9, 9, "FRLFFL", 4, 7, 'W')]
        [TestCase(3, 2, 'S', 9, 9, "RLRFFR", 1, 2, 'N')]
        [TestCase(1, 2, 'N', 9, 9, "FFRFFFRRLF", 4, 3, 'S')]
        public void Test_Simulation_Success_HappyFlow(int xCurrent, int yCurrent, char currentPosition, int x, int y, string command, int xExpected, int yExpected, char expectedPosition)
        {
            var service = _serviceProvider.GetRequiredService<ISimulationHandler>();
            var result = service.PerformSimulation(new Tuple<int, int, char>(xCurrent, yCurrent, currentPosition), new SimulationMatrix() { xAxis = x, yAxis = y }, command.ToArray());
            Assert.AreEqual(xExpected, result.Item1);
            Assert.AreEqual(yExpected, result.Item2);
            Assert.AreEqual(expectedPosition, result.Item3);

        }
        [Test]
        [TestCase(1, 1, 'N', 9, 9, "LFFFFRF", 0, 2, 'N')]
        [TestCase(7, 8, 'E', 9, 9, "FFFFRLFF", 9, 8, 'E')]
        public void Test_Simulation_Success_IgnoredCommand_outOfMaze(int xCurrent, int yCurrent, char currentPosition, int x, int y, string command, int xExpected, int yExpected, char expectedPosition)
        {
            var service = _serviceProvider.GetRequiredService<ISimulationHandler>();
            var result = service.PerformSimulation(new Tuple<int, int, char>(xCurrent, yCurrent, currentPosition), new SimulationMatrix() { xAxis = x, yAxis = y }, command.ToArray());
            Assert.AreEqual(xExpected, result.Item1);
            Assert.AreEqual(yExpected, result.Item2);
            Assert.AreEqual(expectedPosition, result.Item3);
        }
    }
}
