using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    /// <summary>
    /// Схема таблицы
    /// </summary>
    public abstract class DBTableScheme
    {
        protected readonly string _tableName;
        protected readonly string _dbSchemaName;
        protected readonly string _statementName;

        /// <summary>
        /// Имя таблицы
        /// </summary>
        public string TableName { get { return _tableName; } }
        /// <summary>
        /// Имя схемы в БД, к которой принадлежит Таблица
        /// </summary>
        public string DBSchemaName { get { return _dbSchemaName; } }

        /// <summary>
        /// Имя Таблицы с именем Схемы для SQL-запросов
        /// </summary>
        internal string StatementName { get { return _statementName; } }

        public IEnumerable<string> ColumnNames { get { return GetColumnNames(); } }

        public IEnumerable<DBColumn> Columns { get { return GetColumns(); } }

        public IEnumerable<DBColumn> NotIncrementedColumns { get { return GetNotIncrementedColumns(); } } 

        public DBTableScheme(string name, string dbSchemaName)
        {
            _tableName = name;
            _dbSchemaName = DBSchemaName;
            _statementName = string.Concat(dbSchemaName, ".", name);
        }

        protected abstract IEnumerable<DBColumn> GetColumns();

        protected abstract IEnumerable<string> GetColumnNames();

        protected abstract IEnumerable<DBColumn> GetNotIncrementedColumns();
    }

    /// <summary>
    /// Схема твблицы
    /// </summary>
    public class DBTableScheme<TTable, TColumn, TEntity> : DBTableScheme
        where TEntity : DBEntity
        where TTable : DBTable
        where TColumn : TableColumn<TTable, TEntity>
    {

        readonly Dictionary<string, TColumn> _columns = new Dictionary<string, TColumn>();
        readonly List<int> _entityPropertiesMaping = new List<int>();

        /// <summary>
        /// Получение Колонки по её индексу в Схеме
        /// </summary>
        /// <param name="index">Индекс колонки в Схеме</param>
        /// <returns>Возвращает колонку по указанному индексу </returns>
        public TColumn this[int index] { get { return _columns.ElementAt(index).Value; } }
        /// <summary>
        /// Получение экземпляра КОлонки по её Имени
        /// </summary>
        /// <param name="name">Имя колонки</param>
        /// <returns>ВОзвращает колонку по указанному имени</returns>
        public TColumn this[string name] { get { return _columns[name]; } }

        public TColumn KeyColumn { get; private set; }

        /// <summary>
        /// Общее представление колонок таблицы
        /// </summary>
        internal new IEnumerable<TColumn> Columns { get { return _columns.Values; } }
        /// <summary>
        /// Возвращает все имена колонок таблицы
        /// </summary>
        internal new IEnumerable<String> ColumnNames { get { return _columns.Keys; } }
        /// <summary>
        /// Получение всех колонок, которые не являются автоинкрементами. для вставки
        /// </summary>
        /// <returns></returns>
        public new IEnumerable<TColumn> NotIncrementedColumns
        {
            get
            {
                return _columns.Values.Where(c => !c.IsAutoIncrement);
            }
        }

        /// <summary>
        /// Получиство колонок
        /// </summary>
        internal int ColumnCount { get { return _columns.Count; } }

        public DBTableScheme(string name, string dbSchemaName = "dbo") : base(name, dbSchemaName) { }

        /// <summary>
        /// Добавление колонки в Схему
        /// </summary>
        /// <typeparam name="TColumn"></typeparam>
        /// <param name="column"></param>
        internal void AddColumn(TColumn column, int entityPropI, bool primary = false)
        {
            if(column == null)
            {
                CalendarManagment.LogManager.WriteMessage("Попытка добавления пустого экземпляра колонки в Схему таблицы БД!"
                    , new CalendarManagment.MessageParameter("Имя таблицы", _tableName)
                    , new CalendarManagment.MessageParameter("Последствия", "Вставка проигнорирована"));

                return;
            }

            if(_columns.ContainsKey(column.Name))
            {
                CalendarManagment.LogManager.WriteMessage("Повторное добавление колонки в Схему таблицы БД!"
                    , new CalendarManagment.MessageParameter("Имя таблицы", _tableName)
                    , new CalendarManagment.MessageParameter("Имя колонки", column.Name)
                    , new CalendarManagment.MessageParameter("Последствия", "Вставка проигнорирована"));

                return;
            }

            if (primary)
                KeyColumn = column;

            _columns.Add(column.Name, column);
            _entityPropertiesMaping.Add(entityPropI);
        }

        /// <summary>
        /// Получение матрицы Мапинга для данной схемы Таблицы
        /// </summary>
        /// <returns>Матрица мэпинга значений</returns>
        internal DM_SingleEntityMatrix<TEntity, TColumn> GetMatrix()
        {
            return new DM_SingleEntityMatrix<TEntity, TColumn>(_columns.Values.ToArray(), _entityPropertiesMaping.ToArray());
        }

        /// <summary>
        /// Получение списка колонок, исключая указанные
        /// </summary>
        /// <param name="names">Имена исключаемых колонок</param>
        /// <returns>ВОзвращает колонки Схемы, кроме указанных</returns>
        public IEnumerable<TColumn> GetColumnsExclude(params string[] names)
        {
            if (names == null || names.Length == 0)
                return Columns;

            List<TColumn> excepted = new List<TColumn>();

            int i = 0;
            bool skip = false;
            foreach (var column in Columns)
            {
                skip = false;
                for (i = 0; i < names.Length; i++)
                    if (column.Name == names[i])
                    {
                        skip = true;
                        break;
                    }
                if (!skip)
                    excepted.Add(column);
            }

            return excepted;
        }

        #region DBTableScheme

        protected sealed override IEnumerable<DBColumn> GetColumns()
        {
            return this.Columns;
        }

        protected sealed override IEnumerable<string> GetColumnNames()
        {
            return _columns.Keys;
        }

        protected sealed override IEnumerable<DBColumn> GetNotIncrementedColumns()
        {
            return NotIncrementedColumns;
        }

        #endregion
    }
}
