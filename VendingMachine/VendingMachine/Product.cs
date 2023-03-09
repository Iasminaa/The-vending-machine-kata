using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Product
    {
        public string Name { get; } = string.Empty;
        public decimal Price { get; }
        private int Stock { get; set; }

        public Product(string name, decimal price, int stock) 
        { 
            Name = name;
            Price = price;
            Stock = stock; 
        }

        public void Sell()
        {
            Stock -= 1; 
        }

        public bool IsInStock()
        {
            return Stock > 0; 
        }

        public int GetStock() => Stock;
    }
}
