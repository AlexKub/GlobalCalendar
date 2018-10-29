namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка в таблице в БД с типом TINYINT
    /// </summary>
    /// <typeparam name="TTable">Тип Таблицы, которой принадлежит Колонка</typeparam>
    /// <typeparam name="TEntity">Тип сущности, представленной в Таблице</typeparam>
    public class TC_Byte<TTable, TEntity> : TableColumn<TTable, TEntity, byte>
        where TEntity : DBEntity
        where TTable : DBTable
    {
        internal TC_Byte(TTable table, string name, bool nullable = false) 
            : base(table, new DBColumnProperties(System.Data.SqlDbType.TinyInt, name: name, nullable: nullable))
        {
        }

    }
}

