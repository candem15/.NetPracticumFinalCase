using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Dtos.ShoppingList
{
    public class UpdateShoppingListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public List<string> ProductsId { get; set; }
    }
}
