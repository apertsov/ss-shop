using System.Collections.Generic;
using ShopModel.Abstract;
using ShopModel.Entities;

namespace ShopModel.Concrete
{
    public class FakeReceptRepository:IReceptRepository
    {
        private static readonly List<Recept> FakeRecept = new List<Recept> {
                new Recept {Id = 1, NameRecept = "Test1", Description = "description test1", Price = 10},
                new Recept {Id = 2, NameRecept = "Test2", Description = "description test2", Price = 20},
                new Recept {Id = 3, NameRecept = "Test3", Description = "description test3", Price = 30},
                new Recept {Id = 4, NameRecept = "Test4", Description = "description test4", Price = 40},
                new Recept {Id = 5, NameRecept = "Test5", Description = "description test5", Price = 50},
                new Recept {Id = 6, NameRecept = "Test6", Description = "description test6", Price = 60},
                new Recept {Id = 7, NameRecept = "Test7", Description = "description test7", Price = 70},
                new Recept {Id = 8, NameRecept = "Test8", Description = "description test8", Price = 80},
                new Recept {Id = 9, NameRecept = "Test9", Description = "description test9", Price = 90}
         };

        public List<Recept> Recepts
        {
            get { return FakeRecept; }
        }
    }
}
