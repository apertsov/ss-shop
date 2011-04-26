using System.Collections.Generic;
using ShopModel.Entities;

namespace ShopModel.Abstract
{
    public interface IReceptRepository
    {
        List<Recept> Recepts { get; }
    }
}
