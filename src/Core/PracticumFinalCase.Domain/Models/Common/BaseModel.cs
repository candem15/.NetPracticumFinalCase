namespace PracticumFinalCase.Domain.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        virtual public DateTime UpdatedAt { get; set; }
    }
}
