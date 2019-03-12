using System;

namespace BaristaMatic
{
    class Program
    {
        static void Main(string[] args)
        {
            BaristaMatic barista = new BaristaMatic();
            barista.DisplayInventory();
            barista.DisplayMenu();
            
            do {
                HandleInput(Console.ReadLine(), barista);
            } while (true);
        }

        static void HandleInput(string input, BaristaMatic barista)
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
                    barista.MakeDrink(input);
                    break;
                default:
                    Console.WriteLine("Invalid selection: " + input);
                    break;
            }

            barista.DisplayInventory();
            barista.DisplayMenu();
        }
    }
}
