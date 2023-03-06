using System;
namespace ToyRobotProject
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            var robot = new ToyRobot();
            do
            {
                Console.WriteLine("Choose robot command:");
                Console.WriteLine("- PLACE");
                Console.WriteLine("- MOVE");
                Console.WriteLine("- LEFT");
                Console.WriteLine("- RIGHT");
                Console.WriteLine("- REPORT");
                Console.WriteLine();
                
                Console.Write("Command: ");
                string? answer = Console.ReadLine();

                if (string.IsNullOrEmpty(answer) ||
                    !Enum.TryParse(answer.ToUpper(), out Command command))
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid Command");
                    Console.WriteLine();
                    continue;
                }

                switch (command)
                {
                    case Command.PLACE:
                        Console.Write("Place: ");
                        string? placeCommand = Console.ReadLine();
                        Console.Clear();
                        robot.Place(placeCommand);
                        break;
                    case Command.MOVE:
                        Console.Clear();
                        robot.Move();
                        break;
                    case Command.LEFT:
                        Console.Clear();
                        robot.TurnLeft();
                        break;
                    case Command.RIGHT:
                        Console.Clear();
                        robot.TurnRight();
                        break;
                    case Command.REPORT:
                        robot.Report();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

            } while (true);
        }
    }
}