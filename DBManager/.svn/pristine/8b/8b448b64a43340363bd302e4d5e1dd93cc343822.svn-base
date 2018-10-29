namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка БД со значением типа Bit
    /// </summary>
    /// <typeparam name="TTable">Тип таблицы</typeparam>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public class TC_Bit<TTable, TEntity> : TableColumn<TTable, TEntity, bool>
        where TEntity : DBEntity
        where TTable : DBTable
    {
        public TC_Bit(TTable table, string name, bool nullable = false)
            : base(table, new DBColumnProperties(System.Data.SqlDbType.Bit, name: name, nullable: nullable))
        {
        }

    }
}
