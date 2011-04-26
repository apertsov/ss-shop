using System.Collections.Generic;
using ShopModel.Entities;

namespace ShopModel.Abstract
{
    public interface ICategoriesRepository
    {
        List<Category> Categories { get; }
    }
}
