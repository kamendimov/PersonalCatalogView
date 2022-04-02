using System.Data.SQLite;

namespace PersonalCatalogView.Service
{
    public class DatabaseProvider
    {
        private static DatabaseProvider provider = null;
        private static SQLiteConnection dbConnection = null;

        private DatabaseProvider()
        {
            dbConnection = new SQLiteConnection("Data Source=PERSONAL_INFO.db;Version=3;foreign keys=true;");
            dbConnection.Open();
        }

        public static DatabaseProvider GetDatabaseProvider()
        {
            if (provider == null)
            {
                provider = new DatabaseProvider();
            }
            return provider;
        }

        public static SQLiteConnection GetDbConnection()
        {
            return dbConnection;
        }

        public void Release()
        {
            if (dbConnection != null && dbConnection.State == System.Data.ConnectionState.Open)
            {
                dbConnection.Close();
                provider = null;
            }
        }
    }
}
