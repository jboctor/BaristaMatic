using System;
using System.Collections.Generic;

namespace BaristaMatic
{
    class BaristaMatic
    {
        // Ingredient initialization
        private static Ingredient coffee = new Ingredient("Coffee", 0.75m);
        private static Ingredient decafCoffee = new Ingredient("Decaf Coffee", 0.75m);
        private static Ingredient sugar = new Ingredient("Sugar", 0.25m);
        private static Ingredient cream = new Ingredient("Cream", 0.25m);
        private static Ingredient steamedMilk = new Ingredient("Steamed Milk", 0.35m);
        private static Ingredient foamedMilk = new Ingredient("Foamed Milk", 0.35m);
        private static Ingredient espresso = new Ingredient("Espresso", 1.10m);
        private static Ingredient cocoa = new Ingredient("Cocoa", 0.90m);
        private static Ingredient whippedCream = new Ingredient("Whipped Cream", 1.00m);

        // Drink initialization        
        private static Drink coffeeDrink = new Drink(
            "Coffee",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMatic.coffee, 3),
                Tuple.Create(BaristaMatic.sugar, 1),
                Tuple.Create(BaristaMatic.cream, 1)
            }
        );
        private static Drink decafCoffeeDrink = new Drink(
            "Decaf Coffee",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMatic.decafCoffee, 3),
                Tuple.Create(BaristaMatic.sugar, 1),
                Tuple.Create(BaristaMatic.cream, 1)
            }
        );        
        private static Drink caffeLatte = new Drink(
            "Caffe Latte",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMatic.espresso, 2),
                Tuple.Create(BaristaMatic.steamedMilk, 1)
            }
        );        
        private static Drink caffeAmericano = new Drink(
            "Caffe Americano",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMatic.espresso, 3)
            }
        );        
        private static Drink caffeMocha = new Drink(
            "Caffe Mocha",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMatic.espresso, 1),
                Tuple.Create(BaristaMatic.cocoa, 1),
                Tuple.Create(BaristaMatic.steamedMilk, 1),
                Tuple.Create(BaristaMatic.whippedCream, 1)
            }
        );        
        private static Drink cappucino = new Drink(
            "Cappucino",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMatic.espresso, 2),
                Tuple.Create(BaristaMatic.steamedMilk, 1),
                Tuple.Create(BaristaMatic.foamedMilk, 1)
            }
        );

        // Inventory initialization
        private Dictionary<Ingredient, int> inventory = new Dictionary<Ingredient, int>()
        {
            {BaristaMatic.cocoa, 10},
            {BaristaMatic.coffee, 10},
            {BaristaMatic.cream, 10},
            {BaristaMatic.decafCoffee, 10},
            {BaristaMatic.espresso, 10},
            {BaristaMatic.foamedMilk, 10},
            {BaristaMatic.steamedMilk, 10},
            {BaristaMatic.sugar, 10},
            {BaristaMatic.whippedCream, 10}
        };

        // Menu initialization
        private Dictionary<string, Drink> menu = new Dictionary<string, Drink>()
        {
            {"1", BaristaMatic.caffeAmericano},
            {"2", BaristaMatic.caffeLatte},
            {"3", BaristaMatic.caffeMocha},
            {"4", BaristaMatic.cappucino},
            {"5", BaristaMatic.coffeeDrink},
            {"6", BaristaMatic.decafCoffeeDrink}
        };
        
        internal void RestockInventory()
        {
            foreach (Ingredient ingredient in new List<Ingredient>(this.inventory.Keys)) {
                this.inventory[ingredient] = 10;
            }
        }

        internal void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (KeyValuePair<Ingredient, int> itemStock in this.inventory) {
                Console.WriteLine(
                    "{0},{1}",
                    itemStock.Key.Name,
                    itemStock.Value
                );
            }
        }

        internal void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            foreach (KeyValuePair<string, Drink> drink in this.menu) {
                Console.WriteLine(
                    "{0},{1},${2},{3}",
                    drink.Key,
                    drink.Value.Name,
                    drink.Value.GetCost(),
                    this.CanMakeDrink(drink.Value).ToString().ToLower()
                );
            }
        }

        private bool CanMakeDrink(Drink drink)
        {
            foreach (Tuple<Ingredient, int> ingredientAmounts in drink.Ingredients) {
                if (ingredientAmounts.Item2 > this.inventory[ingredientAmounts.Item1]) {
                    return false;
                }
            }

            return true;
        }

        internal void MakeDrink(string input)
        {
            Drink drink = this.menu[input];
            if (!this.CanMakeDrink(drink)) {
                Console.WriteLine("Out of stock: {0}", drink.Name);
            } else {
                foreach (Tuple<Ingredient, int> ingredientAmounts in drink.Ingredients) {
                    this.inventory[ingredientAmounts.Item1] -= ingredientAmounts.Item2;
                }
                Console.WriteLine("Dispensing: {0}", drink.Name);
            }
        }
    }
}