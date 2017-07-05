using System;

namespace ColorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Color Test - Colors available are (R)ed, (B)lue, (G)reen, and (Y)ellow.");
            string colorString = CreateRandomColorString(4);

            Console.WriteLine("Enter four characters to guess the four random colors in order - i.e. RBGY or GGGG");
            var userinput = Console.ReadLine();

            if (IsValidInput(userinput))
            {
                Console.WriteLine();
                Console.WriteLine("Your color string - {0}", userinput.ToUpper());
                Console.WriteLine("Random color string - {0}", colorString);

                // TEST * Re-enter user guess to test against now known random string
                //userinput = Console.ReadLine();
                //Console.WriteLine("Your NEW color string - {0}", userinput.ToUpper());

                EvalUserInputAgainstRandomColorString(userinput, colorString);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #region Methods

        private static void EvalUserInputAgainstRandomColorString(string userinput, string colorString)
        {
            // Iterate through the randomly generated color string
            for (int i = 0; i < 4; i++)
            {
                string c = colorString.Substring(i, 1);
                string u = userinput.Substring(i, 1);

                // If the user guessed the correct color at position (i)...
                if (String.Compare(c, u) == 0)
                {
                    // Output location/color numbers as per requirements (added green text since message looks the same)
                    Console.ForegroundColor = ConsoleColor.Green;
                    LocationColorOutput(i, colorString.Substring(i, 1));
                }
                else
                {
                    // Iterate through the user's guesses to see if the color was guessed in the wrong spot
                    for (int j = 0; j < 4; j++)
                    {
                        u = userinput.Substring(j, 1);
                        if (String.Compare(c, u) == 0)
                        {
                            // Output location/color numbers as per requirements (added red text since message looks the same)
                            Console.ForegroundColor = ConsoleColor.Red;
                            LocationColorOutput(i, colorString.Substring(i, 1));
                            break;
                        }
                    }
                }
            }
        }

        private static void LocationColorOutput(int i, string v)
        {
            // Zero index position get's a plus one during ouput to match requirements
            Console.WriteLine("Location = {0}, Color = {1}", (i+1).ToString(), ColorToNumber(v));
        }

        private static string CreateRandomColorString(int v)
        {
            string colorString = "";
            Random rnd = new Random();

            for (int i = 0; i < v; i++)
            {
                int randomInt = rnd.Next(1, 4);
                colorString += NumberToColor(randomInt);
            }

            return colorString;
        }

        private static bool IsValidInput(string userinput)
        {
            if (userinput.Length == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int ColorToNumber(string color)
        {
            Colors myColor = (Colors)Enum.Parse(typeof(Colors), color);
            return (int)myColor;
        }

        private static string NumberToColor(int number)
        {
            Colors myColor = (Colors)number;
            return myColor.ToString();
        }
        #endregion

        #region Variables/Enums

        enum Colors { R = 1, B = 2, G = 3, Y = 4};

        #endregion
    }
}
