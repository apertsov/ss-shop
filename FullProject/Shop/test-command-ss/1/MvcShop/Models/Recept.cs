using System.Collections.Generic;

namespace MvcShop.Models
{
    public class ReceptIngridient
    {
        public int Id { get; set; }
        public int IdRecept { get; set; }
        public int Ingridient { get; set; }
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
        public ReceptIngridient Load(int idRecept,Ingridient ingridient)
        {
            return null;
        }
    }

    public class Recept
    {
        public int Id { get; set; }
        public string NameRecept { get; set; }
        public string Description { get; set; }
        public string PathToImage { get; set; }
        public List<ReceptIngridient> Ingridients { get; set; }

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