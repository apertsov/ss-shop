using System.Linq;
using ShopModel.Entities;

namespace ShopModel.Abstract
{
    public interface IReceptRepository
    {
        IQueryable<Recept> Recepts { get; }
    }
}
