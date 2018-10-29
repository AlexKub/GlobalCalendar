namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка таблицы БД с типом integer
    /// </summary>
    /// <typeparam name="TTable">Тип Таблицы, которой принадлежит Колонка</typeparam>
    /// <typeparam name="TEntity">Тип сущности, представленной в Таблице</typeparam>
    public class TC_Int32<TTable, TEntity> : TableColumn<TTable, TEntity, int>
        where TEntity : DBEntity
        where TTable : DBTable
    {
        public TC_Int32(TTable table, string name, bool nullable = false) 
            : base(table, new DBColumnProperties(System.Data.SqlDbType.Int, name: name, nullable: nullable))
        {
        }

    }
}
