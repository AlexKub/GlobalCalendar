using CalendarManagment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DBManager
{
    /// <summary>
    /// Общее представление для таблиц БД
    /// </summary>
    public abstract class DBTable
    {
        protected readonly QueryTexts _Queries;

        /// <summary>
        /// Схема текущей Таблицы
        /// </summary>
        private readonly DBTableScheme _scheme;

        /// <summary>
        /// Контекст БД
        /// </summary>
        readonly DBContext _context;

        readonly bool _valid;

        /// <summary>
        /// Экземпляр контекста БД
        /// </summary>
        internal DBContext Context { get { return _context; } }

        /// <summary>
        /// Имя таблицы в БД
        /// </summary>
        public string Name { get { return _scheme.TableName; } }

        /// <summary>
        /// Флаг корректной инициализации экземпляра Таблицы
        /// </summary>
        public bool IsValid { get { return _valid; } }

        /// <summary>
        /// Поулчение имён колонок Таблицы
        /// </summary>
        /// <returns>Возвращает имена колонок в первой строке Таблицы</returns>
        internal IEnumerable<string> GetColumnNames()
        {
            return _scheme.ColumnNames;
        }

        /// <summary>
        /// Создание нового экземпляра Таблицы БД
        /// </summary>
        internal DBTable(DBContext context)
        {
            _scheme = GetScheme();
            if (_scheme == null)
            {
                LogManager.WriteMessage(@"Некорректное создание экземпляра таблицы БД - Подучена пустая ссылка на Схему. 
                                Проверьте корректность создания экземпляра");
            }

            _context = context;

            _valid = (_scheme != null) && (_context != null);

            if (_valid)
                _Queries = CreateQueries();
        }

        private QueryTexts CreateQueries()
        {
            var qt = new QueryTexts();
            string[] queries = new string[4];
            var sb = new System.Text.StringBuilder();
            sb.Append("SELECT ");
            sb.AppendColumnNames(_scheme.Columns);
            sb.AppendLine(" ");
            sb.Append(" FROM ");
            sb.AppendLine(_scheme.StatementName);
            qt.SELECT_ALL_COLUMNS = sb.ToString();

            sb.Append(" WHERE ID = ");
            qt.SELECT_BY_ID = sb.ToString();

            sb.Clear();

            sb.Append("INSERT INTO ");
            sb.Append(_scheme.StatementName);
            sb.Append("(").AppendColumnNames(_scheme.NotIncrementedColumns).Append(")");
            sb.Append(" VALUES ");
            qt.INSERT = sb.ToString();

            sb.Clear();

            sb.Append("DELETE FROM ");
            sb.Append(_scheme.StatementName);
            sb.Append(" WHERE ");
            qt.DELETE = sb.ToString();

            return qt;
        }

        /// <summary>
        /// Создание схемы Таблицы в БД
        /// </summary>
        /// <returns>Возвращает Схему текущей Таблицы</returns>
        protected abstract DBTableScheme GetScheme();

        protected class QueryTexts
        {
            public string SELECT_ALL_COLUMNS { get; internal set; }

            public string SELECT_BY_ID { get; internal set; }

            public string INSERT { get; internal set; }

            public string DELETE { get; internal set; }
        }

        protected void DisposeResourses(SqlCommand com, SqlDataReader reader = null)
        {
            if (reader != null)
                reader.Close();

            if (com != null)
            {
                if (com.Connection != null)
                {
                    com.Connection.Close();
                    com.Connection.Dispose();
                }

                com.Dispose();
            }

        }

        protected void WriteExecuteException(string text, Exception ex, SqlCommand com, params MessageParameter[] additionalParameters)
        {
            List<MessageParameter> parameters = new List<MessageParameter>();
            parameters.Add(new MessageParameter("Имя таблицы", _scheme == null ? "NULL SCHEME" : _scheme.StatementName));
            parameters.Add(new MessageParameter("Запрос", com.CommandText));
            parameters.Add(new MessageParameter("Строка подключения", com.Connection == null ? "NULL Connection" : com.Connection.ConnectionString));
            if (additionalParameters != null && additionalParameters.Length > 0)
                parameters.AddRange(additionalParameters);

            LogManager.WriteException("Возникло исключкние при попытке выбора из БД всех записей", ex, parameters.ToArray());
        }
    }


    public abstract class DBTable<TScheme> : DBTable 
        where TScheme : DBTableScheme
    {
        private TScheme _scheme;

        /// <summary>
        /// Возвращает Схему текущей Таблицы
        /// </summary>
        public TScheme Schema { get { return _scheme; } }

        public DBTable(DBContext context) : base(context) { }

        protected abstract TScheme CreateScheme();

        sealed protected override DBTableScheme GetScheme()
        {
            if (_scheme == null)
                _scheme = CreateScheme();

            return _scheme;
        }
    }
}
