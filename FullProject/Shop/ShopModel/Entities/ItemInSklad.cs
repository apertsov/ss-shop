using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class ItemInSklad
    {
        public int Id { get; set; }
        public Ingridient Ingridient { get; set; }
        public float MinQuantity { get; set; }
        public decimal PriceByKgOrOne { get; set; }
        public float Quantity { get; set; }

        private const string TableName = "tItemInSklad";

        public void Create()
        {
            if (Ingridient==null) throw new ArgumentException("please set field ingridient");
            var command = new SqlCommand(String.Format("INSERT INTO {0} (idIngridient,minQuantity,priceByKgOrOne,Quantity) VALUES (@idIngridient,@minQuantity,@priceByKgOrOne,@quantity)", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@idIngridient", SqlDbType.Int);
            command.Parameters.Add("@minQuantity", SqlDbType.Real);
            command.Parameters.Add("@priceByKgOrOne", SqlDbType.Decimal);
            command.Parameters.Add("@Quantity", SqlDbType.Real);
            command.Parameters["@idIngridient"].Value = Ingridient.Id;
            command.Parameters["@minQuantity"].Value = MinQuantity;
            command.Parameters["@priceByKgOrOne"].Value = PriceByKgOrOne;
            command.Parameters["@Quantity"].Value = Quantity;
            command.ExecuteNonQuery();
        }
        public void Update()
        {
            if (Ingridient==null) throw new ArgumentException("please set ingridient");
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(String.Format("UPDATE {0} SET idIngridient=@idIngridient,minQuantity=@minQuantity,priceByKgOrOne=@priceByKgOrOne,quantity=@quantity WHERE id=@id", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters.Add("@idIngridient", SqlDbType.Int);
            command.Parameters.Add("@minQuantity", SqlDbType.Real);
            command.Parameters.Add("@priceByKgOrOne", SqlDbType.Decimal);
            command.Parameters.Add("@quantity", SqlDbType.Real);
            command.Parameters["@id"].Value = Id;
            command.Parameters["@idIngridient"].Value = Ingridient.Id;
            command.Parameters["@minQuantity"].Value = MinQuantity;
            command.Parameters["@priceByKgOrOne"].Value = PriceByKgOrOne;
            command.Parameters["@quantity"].Value = Quantity;
            command.ExecuteNonQuery();
        }
        public void Delete()
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection);
            command.ExecuteNonQuery();
        }
        public static ItemInSklad Load(int id)
        {
            ItemInSklad itemInSklad = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,idIngridient,minQuantity,priceByKgOrOne,Quantity FROM {0} WHERE id={1}", TableName, id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                itemInSklad = new ItemInSklad();
                var dr = ds.Tables[TableName].Rows[0];
                itemInSklad.Id = id;
                itemInSklad.Ingridient = Ingridient.Load((int) dr["idIngridient"]);
                itemInSklad.MinQuantity = (float) dr["minQuantity"];
                itemInSklad.PriceByKgOrOne = (decimal) dr["priceByKgOrOne"];
                itemInSklad.Quantity = (float)dr["quantity"];
            }
            return itemInSklad;
        }
        public static List<ItemInSklad> LoadAll()
        {
            var listItemInSklad = new List<ItemInSklad>();
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
                    if (ingridient!=null) listItemInSklad.Add(ingridient);
                }
            }
            return listItemInSklad;
        }

    }
}