using System.Data;

namespace DBManager
{
    /// <summary>
    /// Свойства колонки для инициализации
    /// </summary>
    public class DBColumnProperties
    {
        /// <summary>
        /// -1 по умолчанию
        /// </summary>
        public const int DefaultSize = -1;
        /// <summary>
        /// "NO NAME" - Имя для безимянных колонок
        /// </summary>
        public const string DefaultName = "NO NAME";

        /// <summary>
        /// Имя колонки
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Тип в БД
        /// </summary>
        public SqlDbType SqlDBType { get; private set; }

        /// <summary>
        /// Флаг автозаполнения колонки (Колонка будет пропущена при INSERT)
        /// </summary>
        public bool IsAutoIncrement { get; private set; }

        public bool IsID { get; private set; }

        /// <summary>
        /// Размер (по умолчанию -1)
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Допустимы ли значения null (по умолчанию - нет)
        /// </summary>
        public bool IsNullable { get; private set; }

        public DBColumnProperties(  
            SqlDbType sqlDBType
            , string name = DefaultName
            , int size = DefaultSize
            , bool nullable = false
            , bool isID = false
            , bool autoInc = false)
        {
            Name = name;
            SqlDBType = sqlDBType;
            Size = size;
            IsNullable = nullable;
            IsAutoIncrement = autoInc;
            IsID = isID;
        }
    }
}
