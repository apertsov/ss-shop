using System.Collections.Generic;
using ShopModel.Abstract;
using ShopModel.Entities;

namespace ShopModel.Concrete
{
     public class FakeCategoriesRepository : ICategoriesRepository
        {
            private static readonly List<Category> FakeCategories = new List<Category> {
                new Category{Id=1,CategoryName = "Pizza"},
                new Category{Id=2,CategoryName = "National"},
                new Category{Id=3,CategoryName = "Drinks"},
                new Category{Id=4,CategoryName = "Sweets"}
            };

            public List<Category> Categories
            {
                get { return FakeCategories; }
            }
        }
    
}
