using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace AdventOfCode
{
    public class HowAboutANiceGameOfChess
    {
        string input = "abbhdwsy";
        static string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public void Part1()
        {
            string password = "";
            int i = 0;

            while (password.Length < 8)
            {
                string hash = ComputeMD5Hash(input + i.ToString());
                if (hash.StartsWith("00000"))
                {
                    password += hash[5];
                }
                i++;
            }

            Console.WriteLine("Part 1 - Password: " + password);
        }

        public void Part2()
        {
            StringBuilder password = new StringBuilder("xxxxxxxx");
            int i = 0;

            while (password.ToString().Contains('x'))
            {
                string hash = ComputeMD5Hash(input + i.ToString());
                if (hash.StartsWith("00000") && char.IsDigit(hash[5]))
                {
                    int position = int.Parse(hash[5].ToString());
                    if (position < 8 && password[position] == 'x')
                    {
                        password[position] = hash[6];
                    }
                }
                i++;
            }

            Console.WriteLine("Part 2 - Password: " + password);
        }
    }
}