using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Drinks
    {
        private string name;
        public int price { get; private set; }

        public Drinks(string name)
        {
            this.name = name;
            Random rndRest = new Random();
            price = rndRest.Next(30, 50);
        }

        public override string ToString()
        {
            return "Item: " + name + "\t" + price + " Kc";
        }
    }
}
