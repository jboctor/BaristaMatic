using System;

namespace BaristaMatic
{
    class Program
    {
        static void Main(string[] args)
        {
            BaristaMaticBot barista = new BaristaMaticBot();
            Console.Write(barista.DisplayInventory());
            Console.Write(barista.DisplayMenu());
            
            do {
                HandleInput(Console.ReadLine(), barista);
            } while (true);
        }

        static void HandleInput(string input, BaristaMaticBot barista)
        {
            switch (input.ToLower()) {
                case "q":
                    System.Environment.Exit(1);
                    break;
                case "r":
                    barista.RestockInventory();
                    break;
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    Console.WriteLine(barista.MakeDrink(input));
                    break;
                default:
                    Console.WriteLine("Invalid selection: " + input);
                    break;
            }

            Console.Write(barista.DisplayInventory());
            Console.Write(barista.DisplayMenu());
        }
    }
}
