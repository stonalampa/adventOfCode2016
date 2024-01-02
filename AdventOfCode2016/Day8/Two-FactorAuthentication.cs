namespace AdventOfCode
{
    public class TwoFactorAuthentication
    {
        string[] lines = File.ReadAllLines("Day8/input.txt");
        string[,] screen = new string[6, 50];

        private void Rect(int x, int y)
        {
            for (int i = 0; i < y && i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < x && j < screen.GetLength(1); j++)
                {
                    screen[i, j] = "#";
                }
            }
        }

        private void RotateRow(int row, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                string temp = screen[row, screen.GetLength(1) - 1];
                for (int j = screen.GetLength(1) - 1; j > 0; j--)
                {
                    screen[row, j] = screen[row, j - 1];
                }
                screen[row, 0] = temp;
            }
        }

        private void RotateColumn(int column, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                string temp = screen[screen.GetLength(0) - 1, column];
                for (int j = screen.GetLength(0) - 1; j > 0; j--)
                {
                    screen[j, column] = screen[j - 1, column];
                }
                screen[0, column] = temp;
            }
        }

        public void Part1()
        {
            foreach (string line in lines)
            {
                if (line.StartsWith("rotate column"))
                {
                    string[] parts = line.Split(' ');
                    int column = int.Parse(parts[2].Substring(2));
                    int rotationAmount = int.Parse(parts[4]);
                    RotateColumn(column, rotationAmount);
                }
                else if (line.StartsWith("rotate row"))
                {
                    string[] parts = line.Split(' ');
                    int row = int.Parse(parts[2].Substring(2));
                    int rotationAmount = int.Parse(parts[4]);
                    RotateRow(row, rotationAmount);
                }
                else if (line.StartsWith("rect"))
                {
                    string[] parts = line.Split(' ');
                    string[] dimensions = parts[1].Split('x');
                    int width = int.Parse(dimensions[0]);
                    int height = int.Parse(dimensions[1]);
                    Rect(width, height);
                }
            }

            int count = 0;
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    if (screen[i, j] == "#")
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Count: " + count);
        }

        public void Part2()
        {
            // Get the characters from the screen, 10 chars per line
            // 6 rows, 5 columns per character
            char[][,] charactersArray = new char[10][,];
            for (int i = 0; i < 10; i++)
            {
                char[,] characters = new char[6, 5];
                for (int x = i * 5, k = 0; x < (i + 1) * 5; x++, k++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        string currentElement = screen[y, x];
                        if (!string.IsNullOrEmpty(currentElement))
                        {
                            characters[y, k] = currentElement[0];
                        }
                        else
                        {

                            characters[y, k] = ' ';
                        }
                    }
                }
                charactersArray[i] = characters;
            }

            // Print each character
            foreach (var characters in charactersArray)
            {
                for (int row = 0; row < characters.GetLength(0); row++)
                {
                    for (int col = 0; col < characters.GetLength(1); col++)
                    {
                        Console.Write(characters[row, col]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
