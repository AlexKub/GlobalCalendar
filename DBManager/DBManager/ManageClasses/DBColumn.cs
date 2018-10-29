using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    /// <summary>
    /// Схема колонки БД
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DebugInfo()}")]
    public abstract class DBColumn
    {
        #region Fields

        protected readonly SqlDbType _sqlDbType;
        //protected readonly DbType _dbType;
        protected readonly int _size;
        protected readonly string _name;
        protected readonly bool _nullable;
        protected readonly bool _isAutoInc;
        protected readonly bool _isIDColumn;

        #endregion

        #region Properties

        /// <summary>
        /// Имя колонки
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// Тип в БД
        /// </summary>
        public SqlDbType SqlDBType { get { return _sqlDbType; } }

        /// <summary>
        /// Флаг автозаполнения колонки (Колонка будет пропущена при INSERT)
        /// </summary>
        public bool IsAutoIncrement { get { return _isAutoInc; } }

        /// <summary>
        /// Является колонкой с идентификатором
        /// </summary>
        public bool IsID { get { return _isIDColumn; } }

        /// <summary>
        /// Размер (по умолчанию -1)
        /// </summary>
        public int Size { get { return _size; } }

        /// <summary>
        /// Допустимы ли значения null (по умолчанию - нет)
        /// </summary>
        public bool IsNullable { get { return _nullable; } }

        #endregion

        internal DBColumn(DBColumnProperties props)
        {
            if (props == null)
                throw new ArgumentNullException("Создание представления колонки БД с пустой ссылкой на Набор параметров не предусмотрено");

            _sqlDbType = props.SqlDBType;
            _name = props.Name;
            _size = props.Size;
            _nullable = props.IsNullable;
            _isAutoInc = props.IsAutoIncrement;
            _isIDColumn = props.IsID;
        }

        /// <summary>
        /// Создание параметра со свойствами Колокни
        /// </summary>
        /// <param name="value">Значение параметра</param>
        /// <param name="name">Имя параметра (по умолчанию - имя колонки)</param>
        /// <returns>ВОзвращает новый экземпляр Параметра со свойствами текущей Колонки</returns>
        public System.Data.SqlClient.SqlParameter CreateParameter(object value, string name = "")
        {
            var p = new System.Data.SqlClient.SqlParameter();

            p.SqlDbType = _sqlDbType;

            p.ParameterName = string.IsNullOrEmpty(name) ? this._name : name;

            if (_size != DBColumnProperties.DefaultSize)
                p.Size = _size;

            return p;
        }

        internal abstract dynamic GetReaderValue(System.Data.SqlClient.SqlDataReader reader, ref int valIndex);

        protected virtual string DebugInfo()
        {
            return string.Concat(_name, " | ", _sqlDbType.ToString());
        }

    }

    /// <summary>
    /// Типизированное представление колонки БД
    /// </summary>
    /// <typeparam name="TValue">Тип, к которому приводится значение в колонке БД</typeparam>
    [System.Diagnostics.DebuggerDisplay("{DebugInfo()}")]
    public class DBColumn<TSqlClient, TValue> : DBColumn
        where TSqlClient : System.Data.SqlTypes.INullable
    {

        /// <summary>
        /// Экземпляр типа TValue
        /// </summary>
        public Type ManagedValueType { get { return typeof(TValue); } }

        /// <summary>
        /// Управляемый Sql-тип значения Колонки
        /// </summary>
        public Type SqlValueType { get { return typeof(TSqlClient); } }

        /// <summary>
        /// Конвертер значений столбца
        /// </summary>
        public DBValueConverter<TSqlClient, TValue> Converter { get { return DBValueConverter<TSqlClient, TValue>.Instance; } }

        /// <summary>
        /// Создание Представления колонки таблицы в БД
        /// </summary>
        /// <param name="name">Имя колонки</param>
        /// <param name="sqlDBType">Тип значения SQL</param>
        /// <param name="size">Размер (опционально)</param>
        internal DBColumn(DBColumnProperties props) : base(props) { }

        /// <summary>
        /// Проверка корректности значения для колонки
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Возвращает флаг корректности проверяемого значения для текущей колонки</returns>
        public virtual bool IsValidValue(TValue value)
        {
            return (value == null) == IsNullable;
        }

        internal override dynamic GetReaderValue(System.Data.SqlClient.SqlDataReader reader, ref int valIndex)
        {
            return reader.GetFieldValue<TValue>(valIndex);
        }

        protected override string DebugInfo()
        {
            return string.Concat(base.DebugInfo(), " | ", SqlValueType.Name, " | ", ManagedValueType.Name);
        }
    }
}
