using System.Collections.Generic;
using System.Linq;
using ShopModel.Abstract;
using ShopModel.Entities;

namespace ShopModel.Concrete
{
    public class FakeReceptRepository:IReceptRepository
    {
        private static readonly IQueryable<Recept> FakeRecept = new List<Recept>
                {
                    new Recept {Id = 1, NameRecept = "Test1", Description = "description test1"},
                    new Recept {Id = 2, NameRecept = "Test2", Description = "description test2"},
                    new Recept {Id = 3, NameRecept = "Test3", Description = "description test3"}
                }.AsQueryable();

        public IQueryable<Recept> Recepts
        {
            get { return FakeRecept; }
        }
    }
}
