using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Domain.Entities
{
    public class Product : CoreEntity
    {
        private Product() { }
        public Product(string name, string description, int stock, decimal price)
        {
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            Active = true;
        }
        

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}
