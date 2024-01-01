using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class InternetProtocolVersion7
    {
        string[] lines = File.ReadAllLines("Day7/input.txt");

        private bool IsAbba(string word)
        {
            for (int i = 0; i < word.Length - 3; i++)
            {
                if (word[i] == word[i + 3] && word[i + 1] == word[i + 2] && word[i] != word[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        private List<string> GetAbas(string word)
        {
            List<string> abas = new List<string>();
            for (int i = 0; i < word.Length - 2; i++)
            {
                if (word[i] == word[i + 2] && word[i] != word[i + 1])
                {
                    abas.Add(word.Substring(i, 3));
                }
            }

            return abas;
        }

        public void Part1()
        {
            int sum = 0;

            foreach (string line in lines)
            {
                Regex insideBrackets = new Regex(@"\[(.*?)\]");
                MatchCollection insideMatches = insideBrackets.Matches(line);
                List<string> insideWords = insideMatches.Cast<Match>().Select(m => m.Groups[1].Value).ToList();

                bool abbaInside = false;
                foreach (string word in insideWords)
                {
                    if (IsAbba(word))
                    {
                        abbaInside = true;
                        break;
                    }
                }

                if (abbaInside)
                {
                    continue;
                }

                Regex outsideBrackets = new Regex(@"\](.*?)\[");
                MatchCollection outsideMatches = outsideBrackets.Matches("]" + line + "[");
                List<string> outsideWords = outsideMatches.Cast<Match>().Select(m => m.Groups[1].Value).ToList();

                foreach (string word in outsideWords)
                {
                    if (IsAbba(word))
                    {
                        sum++;
                        break;
                    }
                }
            }

            Console.WriteLine("Part 1 - Number of IPs that support TLS: " + sum);
        }


        // * This returns 150, the correct answer is 231
        // * FUCK ME IF I KNOW WHAT IS WRONG HERE
        public void Part2()
        {
            int sum = 0;
            foreach (string line in lines)
            {
                Regex outsideBrackets = new Regex(@"(?:^|\])([^\[\]]+)(?:\[|$)");
                MatchCollection outsideMatches = outsideBrackets.Matches(line);
                List<string> outsideWords = outsideMatches.Cast<Match>().Select(m => m.Groups[1].Value).ToList();

                bool abaOutside = false;
                List<string> abas = new List<string>();

                foreach (string word in outsideWords)
                {
                    abas = GetAbas(word);
                    if (abas.Count != 0)
                    {
                        abaOutside = true;
                        break;
                    }
                }

                if (!abaOutside)
                {
                    continue;
                }

                Regex insideBrackets = new Regex(@"\[(\w+?)\]");
                MatchCollection insideMatches = insideBrackets.Matches(line);
                List<string> insideWords = insideMatches.Cast<Match>().Select(m => m.Groups[1].Value).ToList();

                foreach (string word in insideWords)
                {
                    foreach (string aba in abas)
                    {
                        string bab = aba[1].ToString() + aba[0].ToString() + aba[1].ToString();

                        if (word.Contains(bab))
                        {
                            sum++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Part 2 - Number of IPs that support TLS: " + sum);
        }
    }
}