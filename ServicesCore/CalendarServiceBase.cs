namespace ServicesCore
{
    /// <summary>
    /// Базовый класс для сервисов Календаря
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DebugDisplay()}")]
    public abstract class CalendarServiceBase
    {
        /// <summary>
        /// Тип БД, к которому подключается сервис
        /// </summary>
        public DBType DB_Type { get; private set; }

        /// <summary>
        /// Префикс имени у БД в зависимости от переданного типа
        /// </summary>
        public string TableNamePrefix { get; private set; }

        /// <summary>
        /// Строка подключения
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Новый сервис Календаря
        /// </summary>
        /// <param name="dbType">Тип БД</param>
        /// <param name="conString">Строка подключения к БД внутренних связей</param>
        public CalendarServiceBase(DBType dbType, string conString)
        {
            DB_Type = dbType;
            ConnectionString = conString;
            TableNamePrefix = SelectTableNamePrefix(conString);
        }

        string SelectTableNamePrefix(string conString)
        {
            /*
             * получение префикса имени БД по типу БД
             * для дальнейшего составления имени БД из кусков
             */
            return DBContext.Default.ExecuteScalar(conString,
                "SELECT TypePrefix FROM [dbo].DBTypes"
                , string.Empty);
        }

        string DebugDisplay()
        {
            return DB_Type.ToString();
        }
    }
}
