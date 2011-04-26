using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ShopModel.Entities
{
    public class Recept : IEnumerable
    {
        public int Id { get; set; }
        public string NameRecept { get; set; }
        public string Description { get; set; }
        public string PathToImage { get; set; }
        public List<IngridientInRecept> Ingridients { get; set; }

        private static string tableName = "tRecept";
        public void Create()
        {
            if (string.IsNullOrEmpty(NameRecept)) throw new Exception("null or zero length recept name");
            if (string.IsNullOrEmpty(Description)) throw new Exception("null or zero length recept description");
            if (string.IsNullOrEmpty(PathToImage)) throw new Exception("null or zero length recept path to image");
            var command = new SqlCommand(String.Format("Insert into {0} Values ('{1}','{2}','{3}')", tableName, NameRecept,Description,PathToImage), ShopModel.Entities.ConnectionDb.Connection);
            command.ExecuteNonQuery();
            command = new SqlCommand(String.Format("SELECT max(id) FROM {0} ", tableName), ShopModel.Entities.ConnectionDb.Connection);
            int id = int.Parse(command.ExecuteScalar().ToString());
            Ingridients = IngridientInRecept.LoadAll(id);            
        }

        public void Update()
        {
            if (string.IsNullOrEmpty(NameRecept)) throw new Exception("null or zero length recept name");
            if (string.IsNullOrEmpty(Description)) throw new Exception("null or zero length recept description");
            if (string.IsNullOrEmpty(PathToImage)) throw new Exception("null or zero length recept path to image");
            var command = new SqlCommand(String.Format("UPDATE {0} SET nameRecept='{1}',description='{2}',pathToImage='{3}' Where id={4}", tableName, NameRecept, Description, PathToImage, Id), ShopModel.Entities.ConnectionDb.Connection);
            command.ExecuteNonQuery();      
            foreach (IngridientInRecept ing in Ingridients)
            {
                ing.Update();
            }
        }

        public void Delete()
        {
            foreach (IngridientInRecept ing in Ingridients)
            {
                ing.Delete();
            }
            var command = new SqlCommand(String.Format("Delete From {0} Where id={1}", tableName, Id), ShopModel.Entities.ConnectionDb.Connection);
            command.ExecuteNonQuery();
        }

        public static Recept Load(int id)
        {
            Recept recept = null;
            var da = new SqlDataAdapter(String.Format("Select * From {0} Where id={1}", tableName, id), ShopModel.Entities.ConnectionDb.Connection);
            var data = new DataSet();
            da.Fill(data, tableName);
            if (data.Tables[tableName].Rows.Count > 0)
            {
                recept = new Recept
                {
                    Id = id,
                    NameRecept = data.Tables[tableName].Rows[0][1].ToString(),
                    Description = data.Tables[tableName].Rows[0][2].ToString(),
                    PathToImage = data.Tables[tableName].Rows[0][3].ToString(),
                    Ingridients = IngridientInRecept.LoadAll(id)
                };

            }  
            return recept;
        }

        public static List<Recept>LoadAll()
        {
            List<Recept> listRecept = null;
            var da = new SqlDataAdapter(String.Format("SELECT id FROM {0} ", tableName), ShopModel.Entities.ConnectionDb.Connection);
            var data = new DataSet();
            da.Fill(data, tableName);
            if (data.Tables[tableName].Rows.Count > 0)
            {
                listRecept = new List<Recept>();
                for (int i=0;i<data.Tables[tableName].Rows.Count;i++)
                {
                    int id = int.Parse(data.Tables[tableName].Rows[i]["id"].ToString());
                    Recept recept=Load(id);
                    if (recept!=null)listRecept.Add(recept);
                };

            } 
            return listRecept;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}