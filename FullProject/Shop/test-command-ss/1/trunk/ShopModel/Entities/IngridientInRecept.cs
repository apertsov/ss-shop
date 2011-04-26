using System.Collections.Generic;

namespace ShopModel.Entities
{
    public class IngridientInRecept
    {
        public int Id { get; set; }
        public int IdRecept { get; set; }
        public Ingridient Ingridient { get; set; }
        public float Quantity { get; set; }

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
        public IngridientInRecept Load(int idRecept, int idIngridient)
        {
            return null;
        }
        public static List<IngridientInRecept> LoadAll(int idRecept)
        {
            return null;
        }
    }
}