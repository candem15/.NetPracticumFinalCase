using PracticumFinalCase.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Dtos.ShoppingList
{
    public class ShoppingListDto
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string OwnerUserName { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
