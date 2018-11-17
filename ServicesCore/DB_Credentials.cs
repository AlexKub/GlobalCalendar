namespace ServicesCore
{
    /// <summary>
    /// Параметры подлкючения к БД
    /// </summary>
    public class DB_Credentials
    {
        public string DB_Name { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public bool NTAuth { get; private set; }

        public int Timeout { get; private set; }

        public string ServerName { get; private set; }

        public string ConnectionString { get; private set; }

        public DB_Credentials(string server, string db, string name, string pass)
        {
            ServerName = server;
            DB_Name = db;
            Password = pass;
            UserName = name;
            ConnectionString = DBConStringBuilder.BuildConnectionString(this);
        }
        public DB_Credentials(string server, string db)
        {
            ServerName = server;
            DB_Name = db;
            NTAuth = true;
            ConnectionString = DBConStringBuilder.BuildConnectionString(this);
        }
    }
}
