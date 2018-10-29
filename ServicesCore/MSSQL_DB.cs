using System;
using System.Data.SqlClient;

namespace ServicesCore
{
    /// <summary>
    /// БД MSSQL
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DebugDisplay()}")]
    public class MSSQL_DB : DBContext
    {
        /// <summary>
        /// Выбор первого значения из результата запроса
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="conString">Строка подключения к БД</param>
        /// <param name="select">Запрос к БД</param>
        /// <param name="defaultReturn">Значение по умолчанию при ошибке</param>
        /// <returns>Возвращает первое значение из выборки</returns>
        public override T ExecuteScalar<T>(string conString, string select, T defaultReturn)
        {
            try
            {
                using (var con = new SqlConnection(conString))
                {

                    var com = new SqlCommand();
                    com.CommandText = select;
                    com.Connection = con;
                    con.Open();

                    return (T)com.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                return defaultReturn;
            }
        }

        string DebugDisplay()
        {
            return this.GetType().Name;
        }
    }
}
