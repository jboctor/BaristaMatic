using System;
using System.IO;
using Xunit;

namespace BaristaMatic.Tests
{
    public class BaristaMaticTests
    {
        [Fact]
        public void BaristaMatic_DisplayMenu()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                BaristaMatic barista = new BaristaMatic();
                string expectedOutput = 
@"Menu:
1,Caffe Americano,$3.30,false
2,Caffe Latte,$2.55,false
3,Caffe Mocha,$3.35,false
4,Cappucino,$2.90,false
5,Coffee,$2.75,true
6,Decaf Coffee,$2.75,true";

                Assert.AreEqual(expectedOutput, barista.DisplayMenu());
            }
        }
    }
}