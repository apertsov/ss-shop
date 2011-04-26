using System.Collections.Generic;

namespace MvcShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

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
        
        public static Category Load(int id)
        {
            return null;
        }

        public static List<Category> LoadAll()
        {
            return null;
        }
    }
}