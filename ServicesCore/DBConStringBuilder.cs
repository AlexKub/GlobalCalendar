using System;

namespace ServicesCore
{
    /// <summary>
    /// Построение строки подключения
    /// </summary>
    public static class DBConStringBuilder
    {
        /// <summary>
        /// Построение строки подключения по данным подключения к БД
        /// </summary>
        /// <returns>Возвращает строку подключения к БД</returns>
        public static string BuildConnectionString(DB_Credentials creds)
        {
            if (creds == null)
                throw new ArgumentNullException("Передана пустая ссылка на параметры подключения к БД для формирования строки подключения");

            
            return creds.NTAuth 
                ? $"Server={creds.ServerName};Database={creds.DB_Name};Trusted_Connection=True;"
                : $"Server={creds.ServerName};Database={creds.DB_Name};User Id={creds.UserName};Password={creds.Password};";
        }
    }
}
