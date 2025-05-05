using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioPagina90.PageObjectPattern.Models
{
    public class FruitModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } 
        public FruitModel(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
