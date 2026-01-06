using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Domain.Exceptions;

namespace WarehouseAPI.Domain.Entities
{
    public class Product : CoreEntity
    {
        private Product() { }

        /// <summary>
        /// Creates a new Product.
        /// </summary>
        /// <exception cref="DomainException">Thrown when name is empty or price is negative.</exception>
        public Product(string name, string description, int stock, decimal price)
        {
            EnsureValidState();

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


        protected override void EnsureValidState()
        {
            DomainException.When(string.IsNullOrEmpty(Name), $"{nameof(Name)} cannot be empty.");
            DomainException.When(string.IsNullOrEmpty(Description), $"{nameof(Description)} cannot be empty.");

            DomainException.When(Stock < 0, $"{nameof(Stock)} cannot be less than zero.");
            DomainException.When(Price < 0, $"{nameof(Price)} cannot be less than zero.");

            DomainException.When(Active == false, $"{nameof(Active)} cannot be false on creation");
        }
    }
}
