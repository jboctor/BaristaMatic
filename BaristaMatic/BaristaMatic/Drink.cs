using System;

namespace BaristaMatic
{
    class Drink
    {
        private string name;
        private Tuple<Ingredient, int>[] ingredients;

        public Drink(string name, Tuple<Ingredient, int>[] ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;
        }

        public Decimal GetCost()
        {
            Decimal cost = 0.00m;
            foreach (Tuple<Ingredient, int> ingredient in this.ingredients) {
                cost += ingredient.Item1.Cost * ingredient.Item2;
            }

            return cost;
        }
        public Tuple<Ingredient, int>[] Ingredients { get => ingredients; set => ingredients = value; }
        
        public string Name { get => name; set => name = value; }
    }
}