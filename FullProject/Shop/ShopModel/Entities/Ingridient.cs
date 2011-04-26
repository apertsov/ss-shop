using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string IngridientName { get; set; }
        private const string TableName = "tIngridient";

        public void Create()
        {
            if (string.IsNullOrEmpty(IngridientName)) throw new ArgumentException("please set ingridient name");
            var command = new SqlCommand(String.Format("INSERT INTO {0} (ingridientName) VALUES (@ingridientName)", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@ingridientName", SqlDbType.VarChar);
            command.Parameters["@ingridientName"].Value = IngridientName;
            command.ExecuteNonQuery();
        }
        
        public void Update()
        {
            if (string.IsNullOrEmpty(IngridientName)) throw new ArgumentException("please set ingridient name");
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(String.Format("UPDATE {0} SET ingridientName=@ingridientName WHERE id=@id", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters.Add("@ingridientName", SqlDbType.VarChar);
            command.Parameters["@id"].Value = Id;
            command.Parameters["@ingridientName"].Value = IngridientName;
            command.ExecuteNonQuery();
        }
        
        public void Delete()
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection);
            command.ExecuteNonQuery();
        }

        public static Ingridient Load(int id)
        {
            Ingridient ingridient = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,ingridientName FROM {0} WHERE id={1}", TableName, id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                ingridient = new Ingridient();
                var dr = ds.Tables[TableName].Rows[0];
                ingridient.Id = id;
                ingridient.IngridientName = dr["ingridientName"].ToString();
            }
            return ingridient;
        }

        public static List<Ingridient> LoadAll()
        {
            var listIngridient = new List<Ingridient>();
            var adapter = new SqlDataAdapter("SELECT id FROM " + TableName, ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var ingridient = Load(id);
                    if (ingridient!=null) {listIngridient.Add(ingridient);}
                }
            }
            return listIngridient;
        }
    }
}