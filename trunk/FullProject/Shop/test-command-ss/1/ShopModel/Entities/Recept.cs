using System.Collections.Generic;

namespace ShopModel.Entities
{
    public class Recept
    {
        public int Id { get; set; }
        public string NameRecept { get; set; }
        public string Description { get; set; }
        public string PathToImage { get; set; }
        public List<IngridientInRecept> Ingridients { get; set; }
        
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
        public static Recept Load(int id)
        {
            return null;
        }
        public static List<Recept>LoadAll()
        {
            return null;
        }
    }
}