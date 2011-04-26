using System.Collections.Generic;

namespace ShopModel.Entities
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string IngridientName { get; set; }
        
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

        public static Ingridient Load(int id)
        {
            return null;
        }

        public static List<Ingridient> LoadAll()
        {
            return null;
        }
    }
}