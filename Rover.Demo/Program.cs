using Rover.Models;
using System;
using System.Collections.Generic;

namespace Rover.Demo
{
    class Program
    {
        /// <summary>
        /// Console app used to interact with the rover and display robot output
        /// This console app is to demo the test input and output as defined by the readme
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                
                var output = new List<string>();

                Console.WriteLine("Input:");

                Console.WriteLine("5 5");
                var robotController = new RobotController(5, 5);

                Console.WriteLine("1 2 N");
                robotController.PlaceRover(1, 2, Enums.Facing.N);

                Console.WriteLine("LMLMLMLMM");
                output.Add(robotController.ExecuteCommandsFromInstructions("LMLMLMLMM"));

                Console.WriteLine("3 3 E");
                robotController.PlaceRover(3, 3, Enums.Facing.E);

                Console.WriteLine("MMRMMRMRRM");
                output.Add(robotController.ExecuteCommandsFromInstructions("MMRMMRMRRM"));

                Console.WriteLine("\nOutput:");
                foreach (var response in output)
                {
                    Console.WriteLine(response);
                }

                Console.WriteLine("\nPress any key to end...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured. Try running the application again. Exception: {ex.Message}");
            }
        }
    }
}
