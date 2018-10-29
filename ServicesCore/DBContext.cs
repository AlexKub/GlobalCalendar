namespace ServicesCore
{
    /// <summary>
    /// Обёртка вызовов к БД
    /// </summary>
    public abstract class DBContext
    {
        readonly string m_conString;

        /// <summary>
        /// DBContext по умолчанию
        /// </summary>
        public static DBContext Default { get { return new MSSQL_DB(); } }

        /// <summary>
        /// Выбор первого значения из результата запроса
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="conString">Строка подключения к БД</param>
        /// <param name="select">Запрос к БД</param>
        /// <param name="defaultReturn">Значение по умолчанию при ошибке</param>
        /// <returns>Возвращает первое значение из выборки</returns>
        public abstract T ExecuteScalar<T>(string conString, string select, T defaultReturn);
    }
}
