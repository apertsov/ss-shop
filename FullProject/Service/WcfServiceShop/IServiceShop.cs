using System.Collections.Generic;
using System.ServiceModel;
using ShopModel.Entities;

namespace WcfServiceShop
{
    [ServiceContract]
    public interface IServiceShop
    {
        #region Category
        [OperationContract]
        Category LoadCategory(int id);

        [OperationContract]
        List<Category> LoadAllCategory();

        [OperationContract]
        bool CreateCategory(Category category);

        [OperationContract]
        bool UpdateCategory(Category category);

        [OperationContract]
        bool DeleteCategory(Category category);
        #endregion Category

        #region Ingridient
        [OperationContract]
        Ingridient LoadIngridient(int id);

        [OperationContract]
        List<Ingridient> LoadAllIngridients();

        [OperationContract]
        bool CreateIngridient(Ingridient ingridient);

        [OperationContract]
        bool UpdateIngridient(Ingridient ingridient);

        [OperationContract]
        bool DeleteIngridient(Ingridient ingridient);
        #endregion Ingridient

        #region IngridientInRecept
        [OperationContract]
        IngridientInRecept LoadIngridientInReceptById(int id);

        [OperationContract]
        IngridientInRecept LoadIngridientInRecept(int idRecept,int idIngridient);

        [OperationContract]
        List<IngridientInRecept> LoadAllIngridientsInRecept(int idRecept);

        [OperationContract]
        bool CreateIngridientInRecept(IngridientInRecept ingridientInRecept);

        [OperationContract]
        bool UpdateIngridientInRecept(IngridientInRecept ingridientInRecept);

        [OperationContract]
        bool DeleteIngridientInRecept(IngridientInRecept ingridientInRecept);
        #endregion IngridientInRecept

        #region ItemInSklad
        [OperationContract]
        ItemInSklad LoadItemInSklad(int id);

        [OperationContract]
        List<ItemInSklad> LoadAllItemInSklad();

        [OperationContract]
        bool CreateItemInSklad(ItemInSklad itemInSklad);

        [OperationContract]
        bool UpdateItemInSklad(ItemInSklad itemInSklad);

        [OperationContract]
        bool DeleteItemInSklad(ItemInSklad itemInSklad);
        #endregion Ingridient

        #region Recept
        [OperationContract]
        Recept LoadRecept(int id);

        [OperationContract]
        List<Recept> LoadReceptByCategory(int idCategory);

        [OperationContract]
        List<Recept> LoadAllRecept();

        [OperationContract]
        bool CreateRecept(Recept recept);

        [OperationContract]
        bool UpdateRecept(Recept recept);

        [OperationContract]
        bool DeleteRecept(Recept recept);
        #endregion Recept

        #region ReceptInCategory
        [OperationContract]
        ReceptInCategory LoadReceptInCategory(int id);

        [OperationContract]
        List<ReceptInCategory> LoadReceptInCategoryByCategory(int idCategory);

        
        [OperationContract]
        bool CreateReceptInCategory(ReceptInCategory receptInCategory);

        [OperationContract]
        bool UpdateReceptInCategory(ReceptInCategory receptInCategory);

        [OperationContract]
        bool DeleteReceptInCategory(ReceptInCategory receptInCategory);
        #endregion ReceptInCategory

        #region Order
        [OperationContract]
        Order LoadOrder(int id);

        [OperationContract]
        List<Order> LoadOrderByStatus(OrderStatus orderStatus);

        [OperationContract]
        List<Order> LoadOrderByUserName(string userName);

        [OperationContract]
        List<Order> LoadAllOrder();

        [OperationContract]
        int CreateOrder(Order order);

        [OperationContract]
        bool UpdateOrder(Order order);

        [OperationContract]
        bool DeleteOrder(Order order);
        #endregion Order
    }
    
}
