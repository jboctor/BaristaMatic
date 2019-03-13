using System;
using System.IO;
using Xunit;

namespace BaristaMatic.Tests
{
    public class BaristaMaticBotTests
    {
        [Fact]
        public void BaristaMaticBot_DisplayMenu()
        {
            BaristaMaticBot barista = new BaristaMaticBot();
            string expectedOutput = 
@"Menu:
1,Caffe Americano,$3.30,true
2,Caffe Latte,$2.55,true
3,Caffe Mocha,$3.35,true
4,Cappucino,$2.90,true
5,Coffee,$2.75,true
6,Decaf Coffee,$2.75,true
";

            Assert.Equal(expectedOutput, barista.DisplayMenu());
        }

        [Fact]
        public void BaristaMaticBot_DisplayInventory()
        {
            BaristaMaticBot barista = new BaristaMaticBot();
            string expectedOutput = 
@"Inventory:
Cocoa,10
Coffee,10
Cream,10
Decaf Coffee,10
Espresso,10
Foamed Milk,10
Steamed Milk,10
Sugar,10
Whipped Cream,10
";

            Assert.Equal(expectedOutput, barista.DisplayInventory());
        }

        [Fact]
        public void BaristaMaticBot_MakeDrink()
        {
            BaristaMaticBot barista = new BaristaMaticBot();

            Assert.Equal("Dispensing: Coffee", barista.MakeDrink("5"));

            // Make enough Caffe Americanos until we run out of espresso
            Assert.Equal("Dispensing: Caffe Americano", barista.MakeDrink("1"));
            Assert.Equal("Dispensing: Caffe Americano", barista.MakeDrink("1"));
            Assert.Equal("Dispensing: Caffe Americano", barista.MakeDrink("1"));
            Assert.Equal("Out of stock: Caffe Americano", barista.MakeDrink("1"));
        }

        [Fact]
        public void BaristaMaticBot_RestockInventory()
        {
            BaristaMaticBot barista = new BaristaMaticBot();

            // Make enough Caffe Americanos until we run out of espresso
            barista.MakeDrink("1");
            barista.MakeDrink("1");
            barista.MakeDrink("1");
            Assert.Equal("Out of stock: Caffe Americano", barista.MakeDrink("1"));

            // Restock to make more Caffe Americanos
            barista.RestockInventory();
            
            Assert.Equal("Dispensing: Caffe Americano", barista.MakeDrink("1"));
        }
    }
}