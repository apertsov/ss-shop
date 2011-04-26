using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class IngridientInRecept
    {
        public int Id { get; set; }
        public int IdRecept { get; set; }
        public Ingridient Ingridient { get; set; }
        public float Quantity { get; set; }

        private const string TableName = "tIngridientInRecept";

        public void Create(SqlTransaction transaction)
        {
            if (Ingridient==null) throw new ArgumentException("please set ingridient");
            if (IdRecept<1) throw new ArgumentException("set idRecept");
            if (Ingridient.Id < 1) throw new ArgumentException("set idIngridient");
            var command =
                new SqlCommand(
                    String.Format(
                        "INSERT INTO {0} (idRecept,idIngridient,quantity) VALUES (@idRecept,@idIngridient,@quantity)",
                        TableName), ConnectionDb.Connection, transaction);
            command.Parameters.Add("@idRecept", SqlDbType.Int);
            command.Parameters.Add("@idIngridient", SqlDbType.Int);
            command.Parameters.Add("@quantity", SqlDbType.Real);
            command.Parameters["@idRecept"].Value = IdRecept;
            command.Parameters["@idIngridient"].Value = Ingridient.Id;
            command.Parameters["@quantity"].Value = Quantity;
            command.ExecuteNonQuery();
        }
        public void Update(SqlTransaction transaction)
        {
            if (Ingridient == null) throw new ArgumentException("please set ingridient");
            if (IdRecept < 1) throw new ArgumentException("set idRecept");
            if (Ingridient.Id < 1) throw new ArgumentException("set idIngridient");

            var command = new SqlCommand(String.Format("UPDATE {0} SET idRecept=@idRecept, idIngridient=@idIngridient, quantity=@quantity WHERE id={1}",TableName, Id), ConnectionDb.Connection,transaction);
            command.Parameters.Add("@idRecept", SqlDbType.Int);
            command.Parameters.Add("@idIngridient", SqlDbType.Int);
            command.Parameters.Add("@quantity", SqlDbType.Real);
            command.Parameters["@idRecept"].Value = IdRecept;
            command.Parameters["@idIngridient"].Value = Ingridient.Id;
            command.Parameters["@quantity"].Value = Quantity;
            command.ExecuteNonQuery();
        }
        public void Delete(SqlTransaction transaction)
        {
            if (Id < 1) throw new ArgumentException("wrong Id");
            var command = new SqlCommand(string.Format("DELETE FROM {0} WHERE id={1}", TableName, Id), ConnectionDb.Connection,transaction);
            command.ExecuteNonQuery();
        }

        public static IngridientInRecept Load(int idRecept, int idIngridient)
        {
            IngridientInRecept ingridientInRecept = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,idRecept,idIngridient,quantity FROM {0} WHERE (idRecept={1}) AND (idIngridient={2})", TableName, idRecept,idIngridient), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                ingridientInRecept = new IngridientInRecept();
                var dr = ds.Tables[TableName].Rows[0];
                ingridientInRecept.Id = (int)dr["id"];
                ingridientInRecept.IdRecept = idRecept;
                ingridientInRecept.Ingridient = Ingridient.Load(idIngridient);
                ingridientInRecept.Quantity = (float) dr["quantity"];
            }
            return ingridientInRecept;
        }

        public static IngridientInRecept Load(int id)
        {
            IngridientInRecept ingridientInRecept = null;
            var adapter = new SqlDataAdapter(String.Format("SELECT id,idRecept,idIngridient,quantity FROM {0} WHERE id={1}", TableName, id), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                ingridientInRecept = new IngridientInRecept();
                var dr = ds.Tables[TableName].Rows[0];
                ingridientInRecept.Id = id;
                ingridientInRecept.IdRecept = (int)dr["idRecept"];
                ingridientInRecept.Ingridient = Ingridient.Load((int)dr["idIngridient"]);
                ingridientInRecept.Quantity = (float)dr["quantity"];
            }
            return ingridientInRecept;
        }
        public static List<IngridientInRecept> LoadAll(int idRecept)
        {
            var listIngridientInRecept = new List<IngridientInRecept>();
            var adapter = new SqlDataAdapter(String.Format("SELECT id FROM {0} WHERE idRecept={1}",TableName,idRecept), ConnectionDb.Connection);
            var ds = new DataSet();
            adapter.Fill(ds, TableName);
            if (ds.Tables[TableName].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[TableName].Rows.Count; i++)
                {
                    var dr = ds.Tables[TableName].Rows[i];
                    var id = (int)dr["id"];
                    var ingridientInRecept = Load(id);
                    if (ingridientInRecept!=null) {listIngridientInRecept.Add(ingridientInRecept);}
                }
            }
            return listIngridientInRecept;
        }
    }
}