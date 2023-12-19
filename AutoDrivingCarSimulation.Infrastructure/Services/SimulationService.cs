using AutoDrivingCarSimulation.Application.Interfaces;
using AutoDrivingCarSimulation.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoDrivingCarSimulation.Domain.Helpers.SimulaterHelper;

namespace AutoDrivingCarSimulation.Infrastructure.Services
{
    public class SimulationService : ISimulationService
    {
        public Tuple<int, int, char> PerformCommand(Tuple<int, int, char> currentPosition, int x, int y, char moveCommand)
        {
            var x1 = currentPosition.Item1;
            var y1 = currentPosition.Item2;
            var positon = currentPosition.Item3;

            switch (moveCommand)
            {
                case 'F':
                    moveForward(new Tuple<int,int,char>(x1, y1, positon), x, y, out  x1, out  y1);
                    break;
                case 'L':
                    turnLeftDirection(positon, out positon);
                    break;
                case 'R':
                    turnRightDirection(positon, out positon);
                    break;
                
            }
            return new Tuple<int, int, char>(x1, y1, positon);
        }

        private void moveForward(Tuple<int, int, char> currentPosition, int x, int y,out int x1,out int y1)
        {
        
            switch (currentPosition.Item3)
            {
                //If its face north its moves +1 up (Y axis) and check for max of the maze and 0 check
                case (char)SimulaterHelper.Direction.North:
                    if(currentPosition.Item2 < y && currentPosition.Item2 > 0)
                    {
                        y1 = currentPosition.Item2 + 1;
                        x1 = currentPosition.Item1;
                    }
                    //out of Maze Command Ingnored
                    else
                    {
                        y1 = currentPosition.Item2;
                        x1 = currentPosition.Item1;
                    }
                    break;
                //If its face East its moves +1 right side (X axis) and check for max of the maze and 0 check
                case (char)SimulaterHelper.Direction.East:
                    if (currentPosition.Item1 < x && currentPosition.Item1 > 0)
                    {
                        x1 = currentPosition.Item1 + 1;
                        y1 = currentPosition.Item2;
                    }
                    //out of Maze Command Ingnored
                    else
                    {
                        x1 = currentPosition.Item1;
                        y1 = currentPosition.Item2;
                    }
                    break;
                //If its face South its moves -1 down side (y axis) and check for 0 check that it wont pass the maze
                case (char)SimulaterHelper.Direction.South:
                    if (currentPosition.Item2 > 0)
                    {
                        y1 = currentPosition.Item2 - 1;
                        x1 = currentPosition.Item1;
                    }
                    //out of Maze Command Ingnored
                    else
                    {
                        y1 = currentPosition.Item2;
                        x1 = currentPosition.Item1;
                    }
                    break;
                //If its face West its moves -1 Left side (x axis) and check for 0 check that it wont pass the maze
                case (char)SimulaterHelper.Direction.West:
                    if (currentPosition.Item1 > 0)
                    {
                        x1 = currentPosition.Item1 - 1;
                        y1 = currentPosition.Item2;
                    }
                    //out of Maze Command Ingnored
                    else
                    {
                        x1 = currentPosition.Item1;
                        y1 = currentPosition.Item2;
                    }
                    break;

                    default: 
                        x1 = currentPosition.Item1;
                        y1 = currentPosition.Item2;
                    break;
                    
            }


        }

        private void turnRightDirection(char currectPosition,out char newDirection)
        {
            switch (currectPosition)
            {
                case (char)Direction.North:
                        newDirection = (char)Direction.East;
                    break;

                case (char)Direction.East:
                        newDirection = (char)Direction.South;
                    break;

                case (char)Direction.South:
                        newDirection = (char)Direction.West;
                    break;

                case (char)Direction.West:
                        newDirection = (char)Direction.North;
                    break;

                default:
                    newDirection = currectPosition;
                    break;
            }
        
        }

        private void turnLeftDirection(char currectPosition, out char newDirection)
        {
            switch (currectPosition)
            {
                case (char)Direction.North:
                        newDirection = (char)Direction.West;
                    break;

                case (char)Direction.East:
                        newDirection = (char)Direction.North;
                    break;

                case (char)Direction.South:
                        newDirection = (char)Direction.East;
                    break;

                case (char)Direction.West:
                        newDirection = (char)Direction.South;
                    break;

                default:
                    newDirection = currectPosition;
                    break;
            }
        }
    }
}
