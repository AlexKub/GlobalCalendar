using System;
//using System.Linq;

namespace DBManager
{
    /// <summary>
    /// Коллекция общих статичеких запросов к БД
    /// </summary>
    public abstract class DBStaticQueriesCollection
    {
        protected readonly DBStaticQuery[] _queriesCollection;

        /// <summary>
        /// Количество запросов в коллекции
        /// </summary>
        public int Count { get { return _queriesCollection.Length; } }

        public DBStaticQueriesCollection(DBStaticQuery[] collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Создание Коллекции запросов к БД  по пустой ссылке на массив не предусмотрено");

            _queriesCollection = collection;
        }
    }
}
