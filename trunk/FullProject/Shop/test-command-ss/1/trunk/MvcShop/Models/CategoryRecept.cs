using System.Collections.Generic;

namespace MvcShop.Models
{
    public class CategoryRecept
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Recept Recept { get; set; }

        public bool Create()
        {
            return false;
        }
        public bool Update()
        {
            return false;
        }
        public bool Delete()
        {
            return false;
        }

        public static CategoryRecept LoadByCategory(Category category)
        {
            return null;
        }

        public static List<CategoryRecept> LoadAll() //???? don't know
        {
            return null;
        }
    }
}