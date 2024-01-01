using System.Text;

namespace AdventOfCode
{
    public class SignalsAndNoise
    {
        string[] lines = File.ReadAllLines("Day6/input.txt");

        public void Part1()
        {
            List<StringBuilder> positions = new List<StringBuilder>
            {
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder()
            };

            foreach (string line in lines)
            {
                char[] characters = line.ToCharArray();

                for (int i = 0; i < characters.Length; i++)
                {
                    positions[i].Append(characters[i]);
                }
            }

            string result = string.Join("", positions.Select(pos =>
                {
                    string posAsString = pos.ToString();
                    return posAsString
                        .GroupBy(c => c)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key;
                }));

            Console.WriteLine("Part 1 - Original message: " + result);
        }

        public void Part2()
        {
            List<StringBuilder> positions = new List<StringBuilder>
            {
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder()
            };

            foreach (string line in lines)
            {
                char[] characters = line.ToCharArray();

                for (int i = 0; i < characters.Length; i++)
                {
                    positions[i].Append(characters[i]);
                }
            }

            string result = string.Join("", positions.Select(pos =>
                {
                    string posAsString = pos.ToString();
                    return posAsString
                        .GroupBy(c => c)
                        .OrderBy(g => g.Count())
                        .First()
                        .Key;
                }));

            Console.WriteLine("Part 2 - Original message: " + result);
        }
    }
}