using System.Collections.Generic;

namespace ShopModel.Entities
{
    public class ReceptInCategory
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

        public static ReceptInCategory LoadByCategory(Category category)
        {
            return null;
        }

        public static List<ReceptInCategory> LoadAll() //???? don't know
        {
            return null;
        }
    }
}