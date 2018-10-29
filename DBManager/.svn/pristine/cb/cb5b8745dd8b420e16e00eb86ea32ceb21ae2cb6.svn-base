using System.Data.SqlClient;

namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка таблицы БД с типом NVarChar
    /// </summary>
    /// <typeparam name="TTable">Тип таблицы</typeparam>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public class TC_NVChar<TTable, TEntity> : TableColumn<TTable, TEntity, string>
        where TEntity : DBEntity
        where TTable : DBTable
    {
        public TC_NVChar(TTable table, string name, int size = -1, bool nullable = false) 
            : base(table, new DBColumnProperties(System.Data.SqlDbType.NVarChar, name, size, nullable, false, false))
        {
        }

    }
}
