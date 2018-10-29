using System;

namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка таблицы БД с типом smallint
    /// </summary>
    /// <typeparam name="TTable">Тип экземпляра Таблицы</typeparam>
    /// <typeparam name="TEntity">Тип Сущности</typeparam>
    public sealed class TC_SmallInt<TTable, TEntity> : TableColumn<TTable, TEntity, Int16>
        where TEntity : DBEntity
        where TTable : DBTable
    {
        public TC_SmallInt(TTable table, string name, bool nullable = false) : base(table, 
            new DBColumnProperties(System.Data.SqlDbType.SmallInt
                , name: name
                , nullable: nullable))
        {
        }

    }
}
