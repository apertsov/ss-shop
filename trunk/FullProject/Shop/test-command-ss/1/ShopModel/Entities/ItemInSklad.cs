using System.Collections.Generic;

namespace ShopModel.Entities
{
    public class ItemInSklad
    {
        public int Id { get; set; }
        public Ingridient Ingridient { get; set; }
        public float MinQuantity { get; set; }
        public decimal PriceByKgOrOne { get; set; }
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
        public static ItemInSklad Load(int id)
        {
            return null;
        }
        public static List<ItemInSklad> LoadAll()
        {
            return null;
        }

    }
}