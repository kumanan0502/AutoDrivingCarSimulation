// See https://aka.ms/new-console-template for more information
using AutoDrivingCarSimulation;
using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Auto Driving Car Simulation!");

var serviceProvider = new ServiceCollection()
            .AddSingleton<AutoDrivingSimulation>()
            .AddScoped<ISimulationHandler, SimulationHandler>()
            .AddScoped<ICommonValidator, CommonValidator>()
            .AddTransient<ISimulationService, SimulationService>()
            .BuildServiceProvider();


var messageService = serviceProvider.GetRequiredService<AutoDrivingSimulation>();

messageService.start();
