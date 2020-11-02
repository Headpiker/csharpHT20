
namespace Models
{
    public class Category : Entity
    {
        public string Title { get; set; }
        public Category(string title)
        {
            Title = title;
        }

        public override string EntityType()
            {
                return "Category";
            }

        public Category()
        {
            
        }
    }
}
