using FunkoMania.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Domain.Entities
{
    public class Product : Entity
    {
        protected Product()
        {

        }
        public Product(string name,string category, string description, bool active, decimal price, DateTime dateRegister, string image, int stockQuantity)
        {
            Name = name;
            Category = category;
            Description = description;
            Active = active;
            Price = price;
            DateRegister = dateRegister;
            Image = image;
            StockQuantity = stockQuantity;
        }

        public string Name { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateRegister { get; private set; }
        public string Image { get; private set; }
        public int StockQuantity { get; private set; }
    }
}
