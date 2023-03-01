using PracticumFinalCase.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Domain.Models
{
    public class ShoppingList : BaseModel
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public List<Product> Products { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
