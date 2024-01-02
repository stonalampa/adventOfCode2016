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
                case 6:
                    SignalsAndNoise signalsAndNoise = new SignalsAndNoise();
                    signalsAndNoise.Part1();
                    signalsAndNoise.Part2();
                    break;
                case 7:
                    InternetProtocolVersion7 internetProtocolVersion7 = new InternetProtocolVersion7();
                    internetProtocolVersion7.Part1();
                    internetProtocolVersion7.Part2();
                    break;
                case 8:
                    TwoFactorAuthentication twoFactorAuthentication = new TwoFactorAuthentication();
                    twoFactorAuthentication.Part1();
                    twoFactorAuthentication.Part2();
                    break;
                case 9:
                    ExplosivesInCyberspace explosivesInCyberspace = new ExplosivesInCyberspace();
                    explosivesInCyberspace.Part1();
                    explosivesInCyberspace.Part2();
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                case 21:
                    break;
                case 22:
                    break;
                case 23:
                    break;
                case 24:
                    break;
                case 25:
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