namespace AdventOfCode
{
    public class SquaresWithThreeSides
    {
        private string[] lines = File.ReadAllLines("Day3/input.txt");

        public void Part1()
        {
            int validTriangles = 0;
            foreach (string line in lines)
            {
                string[] sides = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(sides[0]);
                int b = int.Parse(sides[1]);
                int c = int.Parse(sides[2]);

                if (a + b > c && a + c > b && b + c > a)
                {
                    validTriangles++;
                }
            }

            Console.WriteLine($"Part 1 - Valid Triangles: {validTriangles}");
        }

        public void Part2()
        {
            int validTriangles = 0;
            int currentLine = 0;


            while (currentLine < lines.Length)
            {
                string[] line1 = lines[currentLine].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] line2 = lines[currentLine + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] line3 = lines[currentLine + 2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < 3; i++)
                {
                    int a = int.Parse(line1[i]);
                    int b = int.Parse(line2[i]);
                    int c = int.Parse(line3[i]);

                    if (a + b > c && a + c > b && b + c > a)
                    {
                        validTriangles++;
                    }
                }

                currentLine += 3;
            }

            Console.WriteLine($"Part 2 - Valid Triangles: {validTriangles}");
        }
    }
}
