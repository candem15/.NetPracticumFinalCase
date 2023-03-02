using PracticumFinalCase.Application.Dtos.Product;

namespace PracticumFinalCase.Application.Dtos.ShoppingList
{
    public class ShoppingListEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string OwnerUserName { get; set; }
        public List<ProductDto> Products { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
