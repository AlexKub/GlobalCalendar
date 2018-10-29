namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка в таблице в БД с типом DATE
    /// </summary>
    /// <typeparam name="TTable">Тип Таблицы, которой принадлежит Колонка</typeparam>
    /// <typeparam name="TEntity">Тип сущности, представленной в Таблице</typeparam>
    public class TC_Date<TTable, TEntity> : TableColumn<TTable, TEntity, System.DateTime>
        where TEntity : DBEntity
        where TTable : DBTable
    {
        internal TC_Date(TTable table, string name, bool nullable = false) 
            : base(table, new DBColumnProperties(System.Data.SqlDbType.Date, name: name, nullable: nullable))
        {
        }

    }
}
