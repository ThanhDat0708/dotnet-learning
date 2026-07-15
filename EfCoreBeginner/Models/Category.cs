using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreBeginner.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        // một cái category có nhiều product
        public List<Product> Products { get; set; } = new();
    }
}
