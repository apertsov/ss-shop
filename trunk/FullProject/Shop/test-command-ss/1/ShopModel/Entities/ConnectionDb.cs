using System.Data.SqlClient;

namespace ShopModel.Entities
{
    public class ConnectionDb
    {
        static SqlConnection _connection = new SqlConnection();
        public static bool IsOpened { get; set; }

        public static SqlConnection Connection { get { return _connection; } set { _connection = value; } }

        public static void Open()
        {
            if (IsOpened) Connection.Close();
            Connection.Open();
            IsOpened = true;
        }

        public static void Close()
        {
            Connection.Close();
            IsOpened = false;
        }
    }
}