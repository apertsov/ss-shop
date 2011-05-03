using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public enum OrderStatus
    {
        Taken,
        Processed,
        End
    } ;

    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public DateTime OnDateTime { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public string UserName { get; set; }

        private const string TableName = "tOrder";
        
        
        public int Create()
        {
            if (string.IsNullOrEmpty(Name)) throw new ArgumentException("set name ");
            if (string.IsNullOrEmpty(Phone)) throw new ArgumentException("set name ");
            if (string.IsNullOrEmpty(Address)) throw new ArgumentException("set name ");
            if (OrderLines == null) throw new ArgumentException("please set ingridients");
            var transaction = ConnectionDb.Connection.BeginTransaction();
            try
            {
                var command = new SqlCommand(String.Format("INSERT INTO {0} (nname,phone,address,status,startOrder,finishOrder,onDateTime,userName) VALUES (@nName,@phone,@address,@status,@startOrder,@finishOrder,@onDateTime,@userName)", TableName), ConnectionDb.Connection, transaction);
                command.Parameters.Add("@nname", SqlDbType.VarChar);
                command.Parameters.Add("@phone", SqlDbType.VarChar);
                command.Parameters.Add("@address", SqlDbType.VarChar);
                command.Parameters.Add("@status", SqlDbType.Int);
                command.Parameters.Add("@startOrder", SqlDbType.DateTime);
                command.Parameters.Add("@finishOrder", SqlDbType.DateTime);
                command.Parameters.Add("@onDateTime", SqlDbType.DateTime);
                command.Parameters.Add("@userName", SqlDbType.VarChar);
                command.Parameters["@nname"].Value = Name;
                command.Parameters["@phone"].Value = Phone;
                command.Parameters["@address"].Value = Address;
                command.Parameters["@status"].Value = (int)OrderStatus;
                command.Parameters["@startOrder"].Value = Start;
                command.Parameters["@finishOrder"].Value = Finish;
                command.Parameters["@onDateTime"].Value = OnDateTime;
                command.Parameters["@userName"].Value = UserName;
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT MAX(id) FROM "+TableName, ConnectionDb.Connection,transaction);
                Id = (int)command.ExecuteScalar();
                
                foreach (var orderLine in OrderLines)
                {
                    orderLine.IdOrder = Id;
                    orderLine.Create(transaction);
                }
                transaction.Commit();
                return Id;
            }
            catch
            {
                transaction.Rollback();
            }
            return 0;
        }

        public void Update()
        {
            if (OrderLines == null) throw new ArgumentException("please set Order Lines");
            if (Id < 1) throw new ArgumentException("set id");
            var transaction = ConnectionDb.Connection.BeginTransaction();
            try
            {
                var command = new SqlCommand(String.Format("UPDATE {0} SET nname=@nname, phone=@phone, address=@address, status=@status, startOrder=@startOrder, finishOrder=@finishOrder, onDateTime=@onDateTime,userName=@userName WHERE id={1}", TableName, Id), ConnectionDb.Connection, transaction);
                command.Parameters.Add("@nname", SqlDbType.VarChar);
                command.Parameters.Add("@phone", SqlDbType.VarChar);
                command.Parameters.Add("@address", SqlDbType.VarChar);
                command.Parameters.Add("@status", SqlDbType.Int);
                command.Parameters.Add("@startOrder", SqlDbType.DateTime);
                command.Parameters.Add("@finishOrder", SqlDbType.DateTime);
                command.Parameters.Add("@onDateTime", SqlDbType.DateTime);
                command.Parameters.Add("@userName", SqlDbType.VarChar);

                command.Parameters["@nname"].Value = Name;
                command.Parameters["@phone"].Value = Phone;
                command.Parameters["@address"].Value = Address;
                command.Parameters["@status"].Value = OrderStatus;
                command.Parameters["@startOrder"].Value = Start;
                command.Parameters["@finishOrder"].Value = Finish;
                command.Parameters["@onDateTime"].Value = OnDateTime;
                command.Parameters["@userName"].Value = UserName;
                command.ExecuteNonQuery();

                foreach (var orderLine in OrderLines)
                {
                    orderLine.Update(transaction);
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            
        }

        public void ChangeStatus()
        {
            if (Id < 1) throw new ArgumentException("set id");
            var command = new SqlCommand(String.Format("UPDATE {0} SET status=@status WHERE id={1}", TableName, Id), ConnectionDb.Connection);
                command.Parameters.Add("@status", SqlDbType.Int);
                command.Parameters["@status"].Value = OrderStatus;
                command.ExecuteNonQuery();
        }

        public void Delete()
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var transaction = ConnectionDb.Connection.BeginTransaction();
            try
            {
                var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection, transaction);
                command.ExecuteNonQuery();
                foreach (var orderLine in OrderLines)
                {
                    orderLine.Delete(transaction);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            
        }
        public static Order Load(int id)
        {
            Order order = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,nname,phone,address,status,startOrder,finishOrder,onDateTime,userName FROM {0} WHERE id={1}", TableName, id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                order = new Order();
                var dr = ds.Tables[TableName].Rows[0];
                order.Id = id;
                order.Name = dr["nname"].ToString();
                order.Address = dr["address"].ToString();
                order.Phone = dr["phone"].ToString();
                order.OrderStatus = (OrderStatus) dr["status"];
                order.Start = (DateTime) dr["startOrder"];
                order.Finish = (DateTime) dr["finishOrder"];
                order.OnDateTime = (DateTime)dr["onDateTime"];
                order.UserName = dr["userName"].ToString();
                order.OrderLines = OrderLine.LoadByOrderId(order.Id);
            }
            return order;
        }
        public static List<Order>LoadAll()
        {
            var listOrder = new List<Order>();
            var adapter = new SqlDataAdapter("SELECT id FROM " + TableName, ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var order = Load(id);
                    if (order!=null) listOrder.Add(order);
                }
            }
            return listOrder;
        }
        
        public static List<Order> LoadByStatus(OrderStatus orderStatus)
        {
            var listOrder = new List<Order>();
            var os = (int) orderStatus;
            var adapter = new SqlDataAdapter(String.Format("SELECT id FROM {0} WHERE status={1}", TableName, os), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var order = Load(id);
                    if (order!=null) listOrder.Add(order);
                }
            }
            return listOrder;
        }

        public static List<Order> LoadByUserName(string userName)
        {
            var listOrder = new List<Order>();
            if (userName == null) return listOrder;
            var command = new SqlCommand(String.Format("SELECT id FROM {0} WHERE userName=@userName", TableName), ConnectionDb.Connection);
            command.Parameters.Add("@userName", SqlDbType.VarChar);
            command.Parameters["@userName"].Value = userName;

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var order = Load(id);
                    if (order != null) listOrder.Add(order);
                }
            }
            return listOrder;
        }

        
    }
}
