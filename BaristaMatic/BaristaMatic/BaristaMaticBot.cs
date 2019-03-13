using System;
using System.Collections.Generic;

namespace BaristaMatic
{
    public class BaristaMaticBot
    {
        // Ingredient initialization
        public static Ingredient coffee = new Ingredient("Coffee", 0.75m);
        public static Ingredient decafCoffee = new Ingredient("Decaf Coffee", 0.75m);
        public static Ingredient sugar = new Ingredient("Sugar", 0.25m);
        public static Ingredient cream = new Ingredient("Cream", 0.25m);
        public static Ingredient steamedMilk = new Ingredient("Steamed Milk", 0.35m);
        public static Ingredient foamedMilk = new Ingredient("Foamed Milk", 0.35m);
        public static Ingredient espresso = new Ingredient("Espresso", 1.10m);
        public static Ingredient cocoa = new Ingredient("Cocoa", 0.90m);
        public static Ingredient whippedCream = new Ingredient("Whipped Cream", 1.00m);

        // Drink initialization        
        public static Drink coffeeDrink = new Drink(
            "Coffee",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMaticBot.coffee, 3),
                Tuple.Create(BaristaMaticBot.sugar, 1),
                Tuple.Create(BaristaMaticBot.cream, 1)
            }
        );
        public static Drink decafCoffeeDrink = new Drink(
            "Decaf Coffee",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMaticBot.decafCoffee, 3),
                Tuple.Create(BaristaMaticBot.sugar, 1),
                Tuple.Create(BaristaMaticBot.cream, 1)
            }
        );        
        public static Drink caffeLatte = new Drink(
            "Caffe Latte",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMaticBot.espresso, 2),
                Tuple.Create(BaristaMaticBot.steamedMilk, 1)
            }
        );        
        public static Drink caffeAmericano = new Drink(
            "Caffe Americano",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMaticBot.espresso, 3)
            }
        );        
        public static Drink caffeMocha = new Drink(
            "Caffe Mocha",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMaticBot.espresso, 1),
                Tuple.Create(BaristaMaticBot.cocoa, 1),
                Tuple.Create(BaristaMaticBot.steamedMilk, 1),
                Tuple.Create(BaristaMaticBot.whippedCream, 1)
            }
        );        
        public static Drink cappucino = new Drink(
            "Cappucino",
            new Tuple<Ingredient, int>[] {
                Tuple.Create(BaristaMaticBot.espresso, 2),
                Tuple.Create(BaristaMaticBot.steamedMilk, 1),
                Tuple.Create(BaristaMaticBot.foamedMilk, 1)
            }
        );

        // Inventory initialization
        private Dictionary<Ingredient, int> inventory = new Dictionary<Ingredient, int>()
        {
            {BaristaMaticBot.cocoa, 10},
            {BaristaMaticBot.coffee, 10},
            {BaristaMaticBot.cream, 10},
            {BaristaMaticBot.decafCoffee, 10},
            {BaristaMaticBot.espresso, 10},
            {BaristaMaticBot.foamedMilk, 10},
            {BaristaMaticBot.steamedMilk, 10},
            {BaristaMaticBot.sugar, 10},
            {BaristaMaticBot.whippedCream, 10}
        };

        // Menu initialization
        private Dictionary<string, Drink> menu = new Dictionary<string, Drink>()
        {
            {"1", BaristaMaticBot.caffeAmericano},
            {"2", BaristaMaticBot.caffeLatte},
            {"3", BaristaMaticBot.caffeMocha},
            {"4", BaristaMaticBot.cappucino},
            {"5", BaristaMaticBot.coffeeDrink},
            {"6", BaristaMaticBot.decafCoffeeDrink}
        };
        
        public void RestockInventory()
        {
            foreach (Ingredient ingredient in new List<Ingredient>(this.inventory.Keys)) {
                this.inventory[ingredient] = 10;
            }
        }

        public string DisplayInventory()
        {
            string inventoryString = "Inventory:" + Environment.NewLine;
            foreach (KeyValuePair<Ingredient, int> itemStock in this.inventory) {
                inventoryString += string.Format(
                    "{0},{1}{2}",
                    itemStock.Key.Name,
                    itemStock.Value,
                    Environment.NewLine
                );
            }

            return inventoryString;
        }

        public string DisplayMenu()
        {
            string menuString = "Menu:" + Environment.NewLine;
            foreach (KeyValuePair<string, Drink> drink in this.menu) {
                menuString += string.Format(
                    "{0},{1},${2},{3}{4}",
                    drink.Key,
                    drink.Value.Name,
                    drink.Value.GetCost(),
                    this.CanMakeDrink(drink.Value).ToString().ToLower(),
                    Environment.NewLine
                );
            }

            return menuString;
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

        public string MakeDrink(string input)
        {
            Drink drink = this.menu[input];
            if (!this.CanMakeDrink(drink)) {
                
                return string.Format("Out of stock: {0}", drink.Name);
            } else {
                foreach (Tuple<Ingredient, int> ingredientAmounts in drink.Ingredients) {
                    this.inventory[ingredientAmounts.Item1] -= ingredientAmounts.Item2;
                }
                
                return string.Format("Dispensing: {0}", drink.Name);
            }
        }
    }
}