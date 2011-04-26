using System.Collections.Generic;

namespace ShopModel.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string PathToImage { get; set; }

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

        public static Language Load(int id)
        {
            return null;
        }
        public static List<Language> LoadAll()
        {
            return null;
        }
    }
}