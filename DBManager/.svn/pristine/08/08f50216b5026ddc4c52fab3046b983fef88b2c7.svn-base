using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DBManager
{
    /// <summary>
    /// Коллекция таблиц БД
    /// </summary>
    public class DBTablesCollection : IEnumerable<DBTable>
    {
        protected readonly List<DBTable> _tables = new List<DBTable>();

        /// <summary>
        /// Получение Таблицы из Коллекции по её имени
        /// </summary>
        /// <param name="tableName">Имя таблицы в БД</param>
        /// <returns>Возвращает первую таблицу с соответствующим именем или null</returns>
        public DBTable this[string tableName] { get { return _tables.FirstOrDefault(t => t.Name.Equals(tableName)); } }

        /// <summary>
        /// Возвращает количество таблиц в Коллекции
        /// </summary>
        public int Count { get { return _tables.Count; } }

        internal DBTablesCollection(IEnumerable<DBTable> tables)
        {
            if (tables == null)
                throw new ArgumentNullException("Возникло исключение при создании коллекции таблиц БД - передана пустая ссылка на коллекцию");

            _tables.AddRange(tables);
        }

        public IEnumerator<DBTable> GetEnumerator()
        {
            return _tables.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _tables.GetEnumerator();
        }
    }
}
