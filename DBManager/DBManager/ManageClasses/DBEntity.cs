using System.Collections.Generic;

namespace DBManager
{
    /// <summary>
    /// Представление Сущности в БД с ID'шником
    /// </summary>
    /// <typeparam name="T_ID"></typeparam>
    [System.Diagnostics.DebuggerDisplay("{DebugInfo()}")]
    public abstract class DBEntity_WithID<T_ID> : DBEntity
    {
        protected readonly List<string> _strValues = new List<string>();

        /// <summary>
        /// ID в БД
        /// </summary>
        public T_ID ID { get; internal set; }

        /// <summary>
        /// Строковое представление ID'шника
        /// </summary>
        /// <returns>ID.ToString() или пустую строку при null</returns>
        public string ID_ToString()
        {
            if (ID == null)
                return string.Empty;

            return ID.ToString();
        }

        /// <summary>
        /// Конструктор не предполагается к использованию вне DBManager. Сделал открытым для возможности применения
        /// </summary>
        public DBEntity_WithID()
        {
            AddValues();
        }
        public DBEntity_WithID(T_ID id)
        {
            ID = id;
            AddValues();
        }

        protected abstract void AddValues();

        /// <summary>
        /// Возвращает все значения текущего экземпляра без ID
        /// </summary>
        /// <returns>ВОзвращает все значения для вставки в таблицу</returns>
        internal override IEnumerable<string> GetValuesToInsert() { return _strValues; }

        /// <summary>
        /// Возвращает количество Значимых свойств
        /// </summary>
        /// <returns>Количество значимых свойств</returns>
        internal override int ValuePropertiesCount() { return _strValues.Count; }

        /// <summary>
        /// Информация лдя дебагинга
        /// </summary>
        /// <returns>Возвращает ID.ToString()</returns>
        protected virtual string DebugInfo()
        {
            return ID.ToString();
        }
    }
}
