using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.ShoppingListConsumer
{
    public class ShoppingListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string OwnerUserName { get; set; }
        public List<Product> Products { get; set; }
        public DateTime ComplationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public string Measurement { get; set; }
            public decimal Price { get; set; }
        }
    }
}
