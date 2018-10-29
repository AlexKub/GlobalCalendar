

namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка Первичного ключа в таблице БД
    /// </summary>
    /// <typeparam name="T_ID">Тип данных Первичного ключа</typeparam>
    /// <typeparam name="TTable">Тип Таблицы</typeparam>
    /// <typeparam name="TEntity">Тип Сущности</typeparam>
    public abstract class TC_ID<T_ID, TTable, TEntity> : TableColumn<TTable, TEntity, T_ID>
        where TEntity : DBEntity_WithID<T_ID>
        where TTable : DBTable
    {
        public TC_ID(TTable table, DBColumnProperties props) : base(table, props) { }

    }
}
