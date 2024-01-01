namespace AdventOfCode
{
    public class NoTimeForATaxicab
    {
        public void Part1()
        {
            string[] lines = File.ReadAllLines("Day1/input.txt");

            int startingX = 500;
            int startingY = 500;
            int currentX = startingX;
            int currentY = startingY;
            char pointingTo = 'N';

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

                foreach (var part in parts)
                {
                    string trimmedPart = part.Trim();
                    string direction = trimmedPart.Substring(0, 1);
                    int number = int.Parse(trimmedPart.Substring(1));

                    if (direction == "L")
                    {
                        RotateLeft(ref pointingTo);
                        Move(ref currentX, ref currentY, pointingTo, number);
                    }
                    else if (direction == "R")
                    {
                        RotateRight(ref pointingTo);
                        Move(ref currentX, ref currentY, pointingTo, number);
                    }
                }
            }

            int distance = Math.Abs(startingX - currentX) + Math.Abs(startingY - currentY);
            Console.WriteLine("Part 1 - Distance: " + distance);
        }

        public void Part2()
        {
            string[] lines = File.ReadAllLines("Day1/input.txt");
            int startingX = 500;
            int startingY = 500;
            int currentX = startingX;
            int currentY = startingY;
            HashSet<(int, int)> visitedLocations = new HashSet<(int, int)>() { (currentX, currentY) };
            char pointingTo = 'N';

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

                foreach (var part in parts)
                {
                    string trimmedPart = part.Trim();
                    string direction = trimmedPart.Substring(0, 1);
                    int number = int.Parse(trimmedPart.Substring(1));

                    for (int i = 0; i < number; i++)
                    {
                        Move(ref currentX, ref currentY, pointingTo, 1);
                        var currentLocation = (currentX, currentY);

                        if (visitedLocations.Contains(currentLocation))
                        {
                            Console.WriteLine($"Part 2 - Distance: {Math.Abs(currentX) + Math.Abs(currentY)}");
                            return;
                        }

                        visitedLocations.Add(currentLocation);
                    }

                    if (direction == "L")
                    {
                        RotateLeft(ref pointingTo);
                    }
                    else if (direction == "R")
                    {
                        RotateRight(ref pointingTo);
                    }
                }
            }

            Console.WriteLine("No location visited twice.");
        }

        private void RotateLeft(ref char direction)
        {
            switch (direction)
            {
                case 'N': direction = 'W'; break;
                case 'W': direction = 'S'; break;
                case 'S': direction = 'E'; break;
                case 'E': direction = 'N'; break;
            }
        }

        private void RotateRight(ref char direction)
        {
            switch (direction)
            {
                case 'N': direction = 'E'; break;
                case 'E': direction = 'S'; break;
                case 'S': direction = 'W'; break;
                case 'W': direction = 'N'; break;
            }
        }

        private void Move(ref int x, ref int y, char direction, int blocks)
        {
            switch (direction)
            {
                case 'N': y -= blocks; break;
                case 'S': y += blocks; break;
                case 'W': x -= blocks; break;
                case 'E': x += blocks; break;
            }
        }
    }
}
