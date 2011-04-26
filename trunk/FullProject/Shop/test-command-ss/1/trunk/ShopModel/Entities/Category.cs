using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;

namespace ShopModel.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        private static string tableName = "tCategory";
        public void Create()
        {
                if ((CategoryName == null) || (CategoryName.Length == 0)) throw new Exception("null or zero length categoty name");
                var command = new SqlCommand(String.Format("Insert into {0} VAlues ('{1}')", tableName, CategoryName), ShopModel.Entities.ConnectionDb.Connection);
                command.ExecuteNonQuery();
        }
        public void Update()
        {
            if ((CategoryName == null) || (CategoryName.Length == 0)) throw new Exception("null or zero length categoty name");
            var command= new SqlCommand(String.Format("Update {0} SET categoryName='{1}' Where id={2}",tableName,CategoryName,Id), ShopModel.Entities.ConnectionDb.Connection);
            command.ExecuteNonQuery();
            //return false;
        }
        public void Delete()
        {
            var command = new SqlCommand(String.Format("Delete From {0} Where id={1}", tableName, Id), ShopModel.Entities.ConnectionDb.Connection);
            command.ExecuteNonQuery();
            //return false;
        }
        
        public static Category Load(int id)
        {
            Category category=null;
            var da=new SqlDataAdapter(String.Format("Select categoryName From {0} Where id={1}",tableName, id),ShopModel.Entities.ConnectionDb.Connection);
            var data = new DataSet();
            da.Fill(data, tableName);
            if (data.Tables[tableName].Rows.Count > 0) 
            {
                category = new Category
                {
                    Id = id,
                    CategoryName = data.Tables[tableName].Rows[0]["categoryName"].ToString()
                };

            } 
            return category;
        }

        public static List<Category> LoadAll()
        {
            List<Category> listCategory = null;
            var da = new SqlDataAdapter(String.Format("Select id From {0} ", tableName), ShopModel.Entities.ConnectionDb.Connection);
            var data = new DataSet();
            da.Fill(data, tableName);
            if (data.Tables[tableName].Rows.Count > 0)
            {
                listCategory = new List<Category>();
                for (int i=0;i<data.Tables[tableName].Rows.Count;i++)
                {
                    int id = int.Parse(data.Tables[tableName].Rows[i]["id"].ToString());
                    Category category= Load(id);
                    if (category != null) listCategory.Add(category);
                };

            }
            return listCategory;
        }
    }
}