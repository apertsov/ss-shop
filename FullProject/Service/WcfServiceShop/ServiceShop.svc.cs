using System.Collections.Generic;
using System.Data.SqlClient;
using ShopModel.Entities;

namespace WcfServiceShop
{
    public class ServiceShop : IServiceShop
    {
        private static void OpenDb()
        {
            ConnectionDb.Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\shop.mdf;Integrated Security=True;User Instance=True");
            ConnectionDb.Open();
        }

        #region Category
        public Category LoadCategory(int id)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Category.Load(id);
        }
        
        public List<Category> LoadAllCategory()
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Category.LoadAll();
        }

        public bool CreateCategory(Category category)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                category.Create();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateCategory(Category category)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                category.Update();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteCategory(Category category)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                category.Delete();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion Category

        #region Ingridient
        public Ingridient LoadIngridient(int id)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Ingridient.Load(id);
        }

        public List<Ingridient> LoadAllIngridients()
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Ingridient.LoadAll();
        }

        public bool CreateIngridient(Ingridient ingridient)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                ingridient.Create();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateIngridient(Ingridient ingridient)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                ingridient.Update();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteIngridient(Ingridient ingridient)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                ingridient.Delete();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion Ingridient

        #region IngridientInRecept
        public IngridientInRecept LoadIngridientInReceptById(int id)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return IngridientInRecept.Load(id);
        }

        public IngridientInRecept LoadIngridientInRecept(int idRecept,int idIngridient)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return IngridientInRecept.Load(idRecept,idIngridient);
        }

        public List<IngridientInRecept> LoadAllIngridientsInRecept(int idRecept)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return IngridientInRecept.LoadAll(idRecept);
        }

        public bool CreateIngridientInRecept(IngridientInRecept ingridientInRecept)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                ingridientInRecept.Create(null);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateIngridientInRecept(IngridientInRecept ingridientInRecept)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                ingridientInRecept.Update(null);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteIngridientInRecept(IngridientInRecept ingridientInRecept)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                ingridientInRecept.Delete(null);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion IngridientInRecept

        #region ItemInSklad
        public ItemInSklad LoadItemInSklad(int id)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return ItemInSklad.Load(id);
        }

        public List<ItemInSklad> LoadAllItemInSklad()
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return ItemInSklad.LoadAll();
        }

        public bool CreateItemInSklad(ItemInSklad itemInSklad)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                itemInSklad.Create();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateItemInSklad(ItemInSklad itemInSklad)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                itemInSklad.Update();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteItemInSklad(ItemInSklad itemInSklad)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                itemInSklad.Delete();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion Ingridient

        #region Recept
        public Recept LoadRecept(int id)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Recept.Load(id);
        }

        public List<Recept> LoadReceptByCategory(int idCategory)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Recept.LoadByCategory(idCategory);
        }

        public List<Recept> LoadAllRecept()
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Recept.LoadAll();
        }

        public bool CreateRecept(Recept recept)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                recept.Create();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateRecept(Recept recept)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                recept.Update();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteRecept(Recept recept)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                recept.Delete();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion Recept

        #region ReceptInCategory
        public ReceptInCategory LoadReceptInCategory(int id)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return ReceptInCategory.Load(id);
        }

        public List<ReceptInCategory> LoadReceptInCategoryByCategory(int idCategory)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return ReceptInCategory.LoadByCategory(idCategory);
        }

        public bool CreateReceptInCategory(ReceptInCategory receptInCategory)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                receptInCategory.Create();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateReceptInCategory(ReceptInCategory receptInCategory)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                receptInCategory.Update();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteReceptInCategory(ReceptInCategory receptInCategory)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                receptInCategory.Delete();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion ReceptInCategory

        #region Order
        public Order LoadOrder(int id)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Order.Load(id);
        }

        public List<Order> LoadAllOrder()
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Order.LoadAll();
        }

        public List<Order> LoadOrderByStatus(OrderStatus orderStatus)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Order.LoadByStatus(orderStatus);
        }

        public List<Order> LoadOrderByUserName(string userName)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            return Order.LoadByUserName(userName);
        }

        public int CreateOrder(Order order)
        {
            int id;
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                id=order.Create();
            }
            catch
            {
                id = 0;
            }
            return id;
        }

        public bool UpdateOrder(Order order)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                order.Update();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteOrder(Order order)
        {
            if (!ConnectionDb.IsOpened) OpenDb();
            try
            {
                order.Delete();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion Order
    }
}
