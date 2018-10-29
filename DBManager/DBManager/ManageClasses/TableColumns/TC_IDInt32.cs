namespace DBManager.TableColumns
{
    /// <summary>
    /// Колонка Первичного ключа таблицы БД с типом int
    /// </summary>
    /// <typeparam name="TTable">Тип Таблицы, которой принадлежит Колонка</typeparam>
    /// <typeparam name="TEntity">Тип сущности, представленной в Таблице</typeparam>
    public class TC_IDInt32<TTable, TEntity> : TC_ID<int, TTable, TEntity>
        where TEntity : DBEntity_WithID<int>
        where TTable : DBTable
    {
        /// <summary>
        /// Создание экземпляра Колонки
        /// </summary>
        /// <param name="table">Экземпляр Таблица, к которой принадлежит данная колонка</param>
        /// <param name="autoInc">Флаг автоинкрмента (по умолчанию - true)</param>
        /// <param name="name">Точное имя колонки в БД(по умолчанию - ID)</param>
        internal TC_IDInt32(TTable table, bool autoInc = true, string name = "ID") : base(table, new DBColumnProperties(System.Data.SqlDbType.Int
            , name
            , -1
            , false
            , true
            , autoInc))
        { }

    }
}
