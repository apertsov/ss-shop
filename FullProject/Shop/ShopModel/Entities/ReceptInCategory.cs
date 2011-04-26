using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class ReceptInCategory
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdRecept { get; set; }
        private const string TableName = "tReceptInCategory";

        public void Create()
        {
            if (IdCategory<1) throw new ArgumentException("please set idCategory");
            if (IdRecept<1) throw new ArgumentException("please set idRecept");
            var command = new SqlCommand(String.Format("INSERT INTO {0} (idCategory,idRecept) VALUES (@idCategory,@idRecept)", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@idCategory", SqlDbType.Int);
            command.Parameters.Add("@idRecept", SqlDbType.Int);
            command.Parameters["@idCategory"].Value = IdCategory;
            command.Parameters["@idRecept"].Value = IdRecept;
            command.ExecuteNonQuery();
        }
        public void Update()
        {
            if (IdCategory < 1) throw new ArgumentException("please set idCategory");
            if (IdRecept < 1) throw new ArgumentException("please set idRecept");
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(String.Format("UPDATE {0} SET idRecept=@idRecept, idCategory=@idCategory WHERE id=@id", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters.Add("@idCategory", SqlDbType.Int);
            command.Parameters.Add("@idRecept", SqlDbType.Int);
            command.Parameters["@id"].Value = Id;
            command.Parameters["@idCategory"].Value = IdCategory;
            command.Parameters["@idRecept"].Value = IdRecept;
            command.ExecuteNonQuery();
        }
        public void Delete()
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection);
            command.ExecuteNonQuery();
        }

        public static ReceptInCategory Load(int id)
        {
            ReceptInCategory receptInCategory = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,idRecept,idCategory FROM {0} WHERE id={1}", TableName, id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                var dr = ds.Tables[TableName].Rows[0];
                receptInCategory = new ReceptInCategory
                                       {
                                           Id = id,
                                           IdCategory = (int)dr["idCategory"],
                                           IdRecept = (int)dr["idRecept"]
                                       };
            }
            return receptInCategory;
        }

        public static List<ReceptInCategory> LoadByCategory(int idCategory)
        {
            var listReceptInCategory = new List<ReceptInCategory>();
            var adapter = new SqlDataAdapter(String.Format("SELECT id FROM {0} WHERE idCategory={1}", TableName,idCategory), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var receptInCategory = Load(id);
                    if (receptInCategory != null) { listReceptInCategory.Add(receptInCategory); }
                }
            }
            return listReceptInCategory;
        }

    }
}