using System;
namespace myShoesDotnetApi.Models.Enum
{
    public class Category : BaseEntity<int>
    {
        
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
        
    }
}

