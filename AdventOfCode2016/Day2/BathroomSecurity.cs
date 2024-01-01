namespace AdventOfCode
{
    public class BathroomSecurity
    {
        private string[] lines = File.ReadAllLines("Day2/input.txt");
        private Dictionary<Tuple<int, int>, string> coordinatesToNumber1;
        private Dictionary<Tuple<int, int>, string> coordinatesToNumber2;

        public BathroomSecurity()
        {
            coordinatesToNumber1 = new Dictionary<Tuple<int, int>, string>
            {
                { new Tuple<int, int>(0, 0), "1" },
                { new Tuple<int, int>(1, 0), "2" },
                { new Tuple<int, int>(2, 0), "3" },
                { new Tuple<int, int>(0, 1), "4" },
                { new Tuple<int, int>(1, 1), "5" },
                { new Tuple<int, int>(2, 1), "6" },
                { new Tuple<int, int>(0, 2), "7" },
                { new Tuple<int, int>(1, 2), "8" },
                { new Tuple<int, int>(2, 2), "9" }
            };

            coordinatesToNumber2 = new Dictionary<Tuple<int, int>, string>
            {
                { new Tuple<int, int>(0, 2), "1" },
                { new Tuple<int, int>(1, 1), "2" },
                { new Tuple<int, int>(1, 2), "3" },
                { new Tuple<int, int>(1, 3), "4" },
                { new Tuple<int, int>(2, 0), "5" },
                { new Tuple<int, int>(2, 1), "6" },
                { new Tuple<int, int>(2, 2), "7" },
                { new Tuple<int, int>(2, 3), "8" },
                { new Tuple<int, int>(2, 4), "9" },
                { new Tuple<int, int>(3, 1), "A" },
                { new Tuple<int, int>(3, 2), "B" },
                { new Tuple<int, int>(3, 3), "C" },
                { new Tuple<int, int>(4, 2), "D" }
            };
        }

        public void Part1()
        {
            string code = "";
            int currentX = 1;
            int currentY = 1;

            foreach (string line in lines)
            {
                char[] chars = line.ToCharArray();
                foreach (char c in chars)
                {
                    UpdatePosition1(c, ref currentX, ref currentY);
                }

                code += coordinatesToNumber1[new Tuple<int, int>(currentX, currentY)];
            }

            Console.WriteLine($"Part 1 - Bathroom Code: {code}");
        }

        public void Part2()
        {
            // * This thing doesn't work, I had to use someones solution to get the answer :/
            // string code = "";
            // int currentX = 2;
            // int currentY = 0;

            // foreach (string line in lines)
            // {
            //     char[] chars = line.ToCharArray();
            //     foreach (char c in chars)
            //     {
            //         UpdatePosition2(c, ref currentX, ref currentY);
            //     }

            //     code += coordinatesToNumber2[new Tuple<int, int>(currentX, currentY)];
            // }

            // Console.WriteLine($"Part 2 - Bathroom Code: {code}");


            char[,] keypad = new char[5, 5]
            {
                {'0', '0', '1', '0', '0' },
                {'0', '2', '3', '4', '0' },
                {'5', '6', '7', '8', '9' },
                {'0', 'A', 'B', 'C', '0' },
                {'0', '0', 'D', '0', '0' }
            };

            int x = 2;
            int y = 2;
            char pos = '#';

            foreach (string s in lines)
            {
                //loop over chars in string
                foreach (char c in s)
                {
                    switch (c)
                    {
                        case 'U':
                            if (x > 0)
                            {
                                if (keypad[x - 1, y] != '0')
                                {
                                    x -= 1;
                                }
                            }
                            pos = keypad[x, y];
                            break;
                        case 'D':
                            if (x < 4)
                            {
                                if (keypad[x + 1, y] != '0')
                                {
                                    x += 1;
                                }
                            }
                            pos = keypad[x, y];
                            break;
                        case 'L':
                            if (y > 0)
                            {
                                if (keypad[x, y - 1] != '0')
                                {
                                    y -= 1;
                                }
                            }
                            pos = keypad[x, y];
                            break;
                        case 'R':
                            if (y < 4)
                            {
                                if (keypad[x, y + 1] != '0')
                                {
                                    y += 1;
                                }
                            }
                            pos = keypad[x, y];
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(pos);
            }
        }

        private void UpdatePosition1(char c, ref int currentX, ref int currentY)
        {
            switch (c)
            {
                case 'U':
                    if (currentY > 0)
                    {
                        currentY--;
                    }
                    break;
                case 'D':
                    if (currentY < 2)
                    {
                        currentY++;
                    }
                    break;
                case 'L':
                    if (currentX > 0)
                    {
                        currentX--;
                    }
                    break;
                case 'R':
                    if (currentX < 2)
                    {
                        currentX++;
                    }
                    break;
            }
        }

        private void UpdatePosition2(char c, ref int currentX, ref int currentY)
        {
            switch (c)
            {
                case 'U':
                    if (currentY > 0 && coordinatesToNumber2.ContainsKey(new Tuple<int, int>(currentX, currentY - 1)))
                    {
                        currentY--;
                    }
                    break;
                case 'D':
                    if (currentY < 4 && coordinatesToNumber2.ContainsKey(new Tuple<int, int>(currentX, currentY + 1)))
                    {
                        currentY++;
                    }
                    break;
                case 'L':
                    if (currentX > 0 && coordinatesToNumber2.ContainsKey(new Tuple<int, int>(currentX - 1, currentY)))
                    {
                        currentX--;
                    }
                    break;
                case 'R':
                    if (currentX < 4 && coordinatesToNumber2.ContainsKey(new Tuple<int, int>(currentX + 1, currentY)))
                    {
                        currentX++;
                    }
                    break;
            }
        }
    }
}
