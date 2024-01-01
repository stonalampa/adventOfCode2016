namespace AdventOfCode
{
    public class Program
    {
        private static void Run(int day)
        {
            switch (day)
            {
                case 1:
                    NoTimeForATaxicab noTimeForATaxicab = new NoTimeForATaxicab();
                    noTimeForATaxicab.Part1();
                    noTimeForATaxicab.Part2();
                    break;
                case 2:
                    BathroomSecurity bathroomSecurity = new BathroomSecurity();
                    bathroomSecurity.Part1();
                    bathroomSecurity.Part2();
                    break;
                case 3:
                    SquaresWithThreeSides squaresWithThreeSides = new SquaresWithThreeSides();
                    squaresWithThreeSides.Part1();
                    squaresWithThreeSides.Part2();
                    break;
                case 4:
                    SecurityThroughObscurity securityThroughObscurity = new SecurityThroughObscurity();
                    securityThroughObscurity.Part1();
                    securityThroughObscurity.Part2();
                    break;
                case 5:
                    HowAboutANiceGameOfChess howAboutANiceGameOfChess = new HowAboutANiceGameOfChess();
                    howAboutANiceGameOfChess.Part1();
                    howAboutANiceGameOfChess.Part2();
                    break;
            }
        }

        public static void Main()
        {
            Console.WriteLine("Please enter a number from 1 to 25:");

            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out int day) || day < 1 || day > 25)
            {
                Console.WriteLine("Invalid input. Please provide a valid number from 1 to 25.");
                return;
            }

            Run(day);
        }
    }
}