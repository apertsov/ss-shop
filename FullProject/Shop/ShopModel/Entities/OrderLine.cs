using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public Recept Recept { get; set; }
        public int Quantity { get; set; }

        private const string TableName = "tOrderLine";

        public void Create(SqlTransaction transaction)
        {
            if (Recept == null) throw new ArgumentException("please set field ingridient");
            var command = new SqlCommand(String.Format("INSERT INTO {0} (idOrder,idRecept,quantity) VALUES (@idOrder,@idRecept,@quantity)", TableName), ConnectionDb.Connection,transaction);
            command.Parameters.Add("@idOrder", SqlDbType.Int);
            command.Parameters.Add("@idRecept", SqlDbType.Int);
            command.Parameters.Add("@quantity", SqlDbType.Int);
            command.Parameters["@idOrder"].Value = IdOrder;
            command.Parameters["@idRecept"].Value = Recept.Id;
            command.Parameters["@quantity"].Value = Quantity;
            command.ExecuteNonQuery();
        }
        public void Update(SqlTransaction transaction)
        {
            if (Recept == null) throw new ArgumentException("please set ingridient");
            if (Id < 1) throw new ArgumentException("wrong Id");
            if (IdOrder < 1) throw new ArgumentException("wrong IdOrder");
            var command = new SqlCommand(String.Format("UPDATE {0} SET idOrder=@idOrder,idRecept=@idRecept, quantity=@quantity WHERE id=@id", TableName), ConnectionDb.Connection, transaction);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters.Add("@idOrder", SqlDbType.Int);
            command.Parameters.Add("@idRecept", SqlDbType.Int);
            command.Parameters.Add("@quantity", SqlDbType.Int);
            command.Parameters["@id"].Value = Id;
            command.Parameters["@idOrder"].Value = IdOrder;
            command.Parameters["@IdRecept"].Value = Recept.Id;
            command.Parameters["@quantity"].Value = Quantity;
            command.ExecuteNonQuery();
        }
        public void Delete(SqlTransaction transaction)
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection,transaction);
            command.ExecuteNonQuery();
        }

        public static OrderLine Load(int id)
        {
            OrderLine orderLine = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,idOrder,idRecept,quantity FROM {0} WHERE id={1}", TableName, id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                orderLine = new OrderLine();
                var dr = ds.Tables[TableName].Rows[0];
                orderLine.Id = id;
                orderLine.IdOrder = (int)dr["idOrder"];
                orderLine.Recept = Recept.Load((int) dr["idRecept"]);
                orderLine.Quantity = (int) dr["quantity"];
            }
            return orderLine;
        }
        public static List<OrderLine> LoadByOrderId(int orderId)
        {
            var listOrderLine = new List<OrderLine>();
            var adapter = new SqlDataAdapter(String.Format("SELECT id FROM {0} WHERE idOrder={1}", TableName, orderId), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var orderLine = Load(id);
                    if (orderLine != null) listOrderLine.Add(orderLine);
                }
            }
            return listOrderLine;
        }
    }
}
