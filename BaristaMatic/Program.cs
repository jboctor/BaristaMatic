using System;

namespace BaristaMatic
{
    class Program
    {
        string input;
        static void Main(string[] args)
        {
            BaristaMatic = new BaristaMatic();
            
            do {
                input = Console.ReadLine();
                bool valid = isInputValid(input);
            } while (input.ToLower() != "q");
        }

        static bool isInputValid(string input)
        {

        }
    }
}
