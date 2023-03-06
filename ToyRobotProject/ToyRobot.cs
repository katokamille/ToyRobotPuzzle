namespace ToyRobotProject
{
    public class ToyRobot
    {
        private const int TABLE_WIDTH = 5;
        private const int TABLE_HEIGHT = 5;

        private int x;
        private int y;
        private Direction? direction;
        private bool moved;

        public ToyRobot()
        {
            x = -1;
            y = -1;
            moved = false;
        }

        public void Place(string command)
        {
            string[] parameters = command.Split(',');
            Direction? directionParam = null;
            if (parameters.Count() == 3 &&
                Enum.TryParse(parameters[2].ToUpper(), out Direction dir))
                directionParam = dir;

            if (command.Count(Char.IsWhiteSpace) > 1 ||
                (moved && (parameters.Length < 2 || parameters.Length > 3)) ||
                (!moved && parameters.Length != 3) ||
                (parameters.Length == 3 && directionParam is null) ||
                !int.TryParse(parameters[0], out int xPosition) ||
                !int.TryParse(parameters[1], out int yPosition))
            {
                Console.WriteLine("Error: Invalid place command");
                return;
            }

            Place(xPosition, yPosition, directionParam);

        }

        private void Place(int x, int y, Direction? direction)
        {
            moved = true;
            if (x < 0 || x >= TABLE_WIDTH || y < 0 || y >= TABLE_HEIGHT)
            {
                Console.WriteLine("Error: Invalid position");
                return;
            }

            this.x = x;
            this.y = y;
            this.direction = direction ?? this.direction;
        }

        public void Move()
        {
            if (!moved)
            {
                Console.WriteLine("Error: Robot not placed on table");
                return;
            }

            int newX = x;
            int newY = y;
            switch (direction)
            {
                case Direction.NORTH:
                    newY++;
                    break;
                case Direction.EAST:
                    newX++;
                    break;
                case Direction.SOUTH:
                    newY--;
                    break;
                case Direction.WEST:
                    newX--;
                    break;
            }

            if (newX < 0 || newX >= TABLE_WIDTH || newY < 0 || newY >= TABLE_HEIGHT)
            {
                Console.WriteLine("Error: Invalid move");
                return;
            }

            x = newX;
            y = newY;
        }

        public void TurnLeft()
        {
            if (!moved)
            {
                Console.WriteLine("Error: Robot not placed on table");
                return;
            }

            direction = (Direction)(((int)direction + 3) % 4);
        }

        public void TurnRight()
        {
            if (!moved)
            {
                Console.WriteLine("Error: Robot not placed on table");
                return;
            }

            direction = (Direction)(((int)direction + 1) % 4);
        }

        public void Report()
        { 
            if (!moved)
            {
                Console.WriteLine("Error: Robot not placed on table");
                return;
            }

            Console.WriteLine($"Report: {x},{y},{direction}");
        }
    }
}
