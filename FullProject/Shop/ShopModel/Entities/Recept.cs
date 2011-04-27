using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class Recept
    {
        public int Id { get; set; }
        public string NameRecept { get; set; }
        public string Description { get; set; }
        public string PathToImage { get; set; }
        public decimal Price { get; set; }
        public int TimeCooking { get; set; }
        public List<IngridientInRecept> Ingridients { get; set; }

        private const string TableName = "tRecept";
        
        public void Create()
        {
            if (string.IsNullOrEmpty(NameRecept)) throw new ArgumentException("set name recept");
            if (Ingridients == null) throw new ArgumentException("please set ingridients");
            var transaction = ConnectionDb.Connection.BeginTransaction();
            try
            {
                var command = new SqlCommand(String.Format("INSERT INTO {0} (nameRecept,description,pathToImage,price,timeCooking) VALUES (@nameRecept,@description,@pathToImage,@price,@timeCooking)", TableName), ConnectionDb.Connection, transaction);
                command.Parameters.Add("@nameRecept", SqlDbType.VarChar);
                command.Parameters.Add("@description", SqlDbType.VarChar);
                command.Parameters.Add("@pathToImage", SqlDbType.VarChar);
                command.Parameters.Add("@timeCooking", SqlDbType.Int);
                command.Parameters.Add("@price", SqlDbType.Money);
                command.Parameters["@nameRecept"].Value = NameRecept;
                command.Parameters["@description"].Value = Description;
                command.Parameters["@pathToImage"].Value = PathToImage;
                command.Parameters["@timeCooking"].Value = TimeCooking;
                command.Parameters["@price"].Value = Price;
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT MAX(id) FROM "+TableName, ConnectionDb.Connection,transaction);
                Id = (int)command.ExecuteScalar();
                
                foreach (var ingridientInRecept in Ingridients)
                {
                    ingridientInRecept.IdRecept = Id;
                    ingridientInRecept.Create(transaction);
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

        }
        public void Update()
        {
            if (Ingridients == null) throw new ArgumentException("please set ingridient");
            if (Id < 1) throw new ArgumentException("set id");
            var transaction = ConnectionDb.Connection.BeginTransaction();
            try
            {
                var command = new SqlCommand(String.Format("UPDATE {0} SET nameRecept=@nameRecept, description=@description, pathToImage=@pathToImage, timeCooking=@timeCooking, price=@price WHERE id={1}", TableName, Id), ConnectionDb.Connection, transaction);
                command.Parameters.Add("@nameRecept", SqlDbType.VarChar);
                command.Parameters.Add("@description", SqlDbType.VarChar);
                command.Parameters.Add("@pathToImage", SqlDbType.VarChar);
                command.Parameters.Add("@timeCooking", SqlDbType.Int);
                command.Parameters.Add("@price", SqlDbType.Money);
                command.Parameters["@nameRecept"].Value = NameRecept;
                command.Parameters["@description"].Value = Description;
                command.Parameters["@pathToImage"].Value = PathToImage;
                command.Parameters["@timeCooking"].Value = TimeCooking;
                command.Parameters["@price"].Value = Price;
                command.ExecuteNonQuery();
                foreach (var ingridientInRecept in Ingridients)
                {
                    ingridientInRecept.Update(transaction);
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            
        }
        public void Delete()
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var transaction = ConnectionDb.Connection.BeginTransaction();
            try
            {
                var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection, transaction);
                command.ExecuteNonQuery();
                foreach (var ingridientInRecept in Ingridients)
                {
                    ingridientInRecept.Delete(transaction);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            
        }
        public static Recept Load(int id)
        {
            Recept recept = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,nameRecept,description,pathToImage, timeCooking, price FROM {0} WHERE id={1}", TableName, id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                recept = new Recept();
                var dr = ds.Tables[TableName].Rows[0];
                recept.Id = id;
                recept.NameRecept = dr["nameRecept"].ToString();
                recept.Description = dr["description"].ToString();
                recept.PathToImage = dr["pathToImage"].ToString();
                recept.TimeCooking = (int)dr["timeCooking"];
                recept.Price = (decimal) dr["price"];
                recept.Ingridients = IngridientInRecept.LoadAll(recept.Id);
            }
            return recept;
        }
        public static List<Recept>LoadAll()
        {
            var listRecept = new List<Recept>();
            var adapter = new SqlDataAdapter("SELECT id FROM " + TableName, ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var recept = Load(id);
                    if (recept!=null) listRecept.Add(recept);
                }
            }
            return listRecept;
        }
        
        public static List<Recept> LoadByCategory(int idCategory)
        {
            var listRecept = new List<Recept>();
            var adapter = new SqlDataAdapter("SELECT idRecept FROM tReceptInCategory WHERE idCategory=" + idCategory, ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["idRecept"];
                    var recept = Load(id);
                    if (recept!=null) listRecept.Add(recept);
                }
            }
            return listRecept;
        }
    }
}