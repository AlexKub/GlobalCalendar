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
        /// Суффикс локали БД
        /// </summary>
        public string DB_Locale { get; private set; }

        /// <summary>
        /// Префикс имени у БД в зависимости от переданного типа
        /// </summary>
        public string DBTypePrefix { get; private set; }

        /// <summary>
        /// Генерируемое имя рабочей БД
        /// </summary>
        public string DB_Name { get; private set; }

        /// <summary>
        /// Параметры подключения к БД связей
        /// </summary>
        public DB_Credentials InternalCreds { get; private set; }

        /// <summary>
        /// Параметры подключения к рабочей БД
        /// </summary>
        public DB_Credentials WorkCreds { get; private set; }

        /// <summary>
        /// Новый сервис Календаря
        /// </summary>
        /// <param name="dbType">Тип БД</param>
        /// <param name="conString">Строка подключения к БД внутренних связей</param>
        public CalendarServiceBase(DBType dbType, DB_Credentials intern, DB_Credentials work)
        {
            DB_Type = dbType;
            InternalCreds = intern;
            WorkCreds = work;

            //определяем части будующего имени рабчей БД
            DBTypePrefix = SelectTableNamePrefix(intern.ConnectionString);
            DB_Locale = SelectLocaleSuffix();

            //имя генерируется из префикса и локали
            DB_Name = GenerateDBName();
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

        string SelectLocaleSuffix()
        {
            return "RUS";
        }

        string GenerateDBName()
        {
            return DBTypePrefix + "_" + DB_Locale;
        }

        string DebugDisplay()
        {
            return DB_Type.ToString() + " | " + (string.IsNullOrEmpty(DB_Name) ? "NO NAME" : DB_Name);
        }
    }
}
