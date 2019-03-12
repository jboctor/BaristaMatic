using System;

namespace BaristaMatic
{
    class Ingredient
    {
        private string name;
        private Decimal cost;

        public Ingredient(string name, Decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }
        public string Name { get => name; set => name = value; }
        
        public Decimal Cost { get => cost; set => cost = value; }

    }
}