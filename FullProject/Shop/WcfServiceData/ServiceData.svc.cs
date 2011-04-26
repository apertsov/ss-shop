using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ShopModel.Entities;

namespace WcfServiceData
{
    public class ServiceData : IServiceData
    {
        private static void OpenDb()
        {
            ConnectionDb.Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\shop.mdf;Integrated Security=True;User Instance=True");
            ConnectionDb.Open();
        }

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

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        
    }
}
