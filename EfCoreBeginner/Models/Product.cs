using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreBeginner.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
        //khóa ngoại
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        //  đây goi là navigation property, nó sẽ giúp mình truy xuất đến category của product này
        public Category Category { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
    }
}
