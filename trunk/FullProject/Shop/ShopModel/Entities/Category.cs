using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        private const string TableName = "tCategory";
        public void Create()
        {
            if (string.IsNullOrEmpty(CategoryName)) throw new ArgumentException("please set category name");
            var command = new SqlCommand(String.Format("INSERT INTO {0} (categoryName) VALUES (@categoryName)",TableName),ConnectionDb.Connection);
            command.Parameters.Add("@categoryName", SqlDbType.VarChar);
            command.Parameters["@categoryName"].Value = CategoryName;
            command.ExecuteNonQuery();
        }
        public void Update()
        {
            if (string.IsNullOrEmpty(CategoryName)) throw new ArgumentException("please set category name");
            if (Id<1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(String.Format("UPDATE {0} SET categoryName=@categoryName WHERE id=@id", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters.Add("@categoryName", SqlDbType.VarChar);
            command.Parameters["@id"].Value = Id;
            command.Parameters["@categoryName"].Value = CategoryName;
            command.ExecuteNonQuery();
        }
        public void Delete()
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection);
            command.ExecuteNonQuery();
        }
        
        public static Category Load(int id)
        {
            Category category = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,categoryName FROM {0} WHERE id={1}", TableName,id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                category = new Category();
                var dr = ds.Tables[TableName].Rows[0];
                category.Id = id;
                category.CategoryName = dr["categoryName"].ToString();
            }
            return category;
        }

        public static List<Category> LoadAll()
        {
            var listCategory = new List<Category>();
            var adapter = new SqlDataAdapter("SELECT id FROM "+TableName, ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i=0;i<ds.Tables[TableName].Rows.Count;i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id =(int)dr["id"];
                    var category = Load(id);
                    if (category!=null) {listCategory.Add(category);}
                }
            }
            return listCategory;
        }
    }
}