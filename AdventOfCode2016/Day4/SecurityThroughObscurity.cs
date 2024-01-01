using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class SecurityThroughObscurity
    {
        private string[] lines = File.ReadAllLines("Day4/input.txt");

        public void Part1()
        {
            int sum = 0;
            string pattern = @"^([\w-]+)-(\d+)\[([\w]+)\]$";

            foreach (string line in lines)
            {
                Match match = Regex.Match(line, pattern);
                string[] words = match.Groups[1].Value.Split('-');
                string number = match.Groups[2].Value;
                string checkSum = match.Groups[3].Value;

                Dictionary<char, int> map = new Dictionary<char, int>();
                foreach (string word in words)
                {
                    foreach (char c in word)
                    {
                        if (map.ContainsKey(c))
                        {
                            map[c]++;
                        }
                        else
                        {
                            map.Add(c, 1);
                        }
                    }
                }

                var sortedMap = map.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

                string top5 = "";
                foreach (var pair in sortedMap.Take(5))
                {
                    top5 += pair.Key;
                }

                if (top5 == checkSum)
                {
                    sum += int.Parse(number);
                }
            }
            Console.WriteLine($"Part 1 - Sum: {sum}");
        }

        public void Part2()
        {
            string pattern = @"^([\w-]+)-(\d+)\[([\w]+)\]$";
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, pattern);
                string[] words = match.Groups[1].Value.Split('-');
                string number = match.Groups[2].Value;
                string decrypted = "";

                foreach (string word in words)
                {
                    foreach (char c in word)
                    {
                        decrypted += (char)(((c - 'a') + int.Parse(number)) % 26 + 'a');
                    }
                    decrypted += " ";
                }

                if (decrypted.Contains("northpole"))
                {
                    Console.WriteLine($"Part 2 - Sector ID: {number}");
                }
            }
        }
    }
}