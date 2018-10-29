using System;
using System.Data.SqlClient;

namespace DBManager
{

    /// <summary>
    /// Колонка таблицы БД
    /// </summary>
    /// <typeparam name="TTable">Тип таблицы</typeparam>
    /// <typeparam name="TEntity">Таблица с сущностями</typeparam>
    public abstract class TableColumn<TTable, TEntity> : DBColumn
        where TEntity : DBEntity
        where TTable : DBTable
    {
        protected readonly TTable _table;

        /// <summary>
        /// Таблица, к которой принадлежит данная колонка
        /// </summary>
        public TTable Table { get { return _table; } }

        internal TableColumn(TTable table, DBColumnProperties props) : base(props)
        {
            if (string.IsNullOrWhiteSpace(props.Name) || props.Name == DBColumnProperties.DefaultName)
                throw new ArgumentException("Создание табличной Колонки таблицы с пустым именем или именем по умолчанию не предсмотрено. Задайте явно имя колонки, соответствующее таковому в БД");
            _table = table;
        }
    }

    /// <summary>
    /// Колонка таблицы БД
    /// </summary>
    /// <typeparam name="TTable">Тип таблицы</typeparam>
    /// <typeparam name="TEntity">Таблица с сущностями</typeparam>
    /// <typeparam name="TValue">Тип значения в управляемом коде</typeparam>
    public abstract class TableColumn<TTable, TEntity, TValue> : TableColumn<TTable, TEntity>
        where TEntity : DBEntity
        where TTable : DBTable
    {
        internal TableColumn(TTable table, DBColumnProperties props) : base(table, props) { }

        internal sealed override dynamic GetReaderValue(SqlDataReader reader, ref int valIndex)
        {
            return reader.GetFieldValue<TValue>(valIndex);
        }
    }
}
