using System.Text;

namespace DBManager
{
    /// <summary>
    /// Условие SQL-зароса
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class SqlQueryCondition
    {
        /// <summary>
        /// Колонка
        /// </summary>
        public DBColumn Column { get; private set; }

        /// <summary>
        /// Знак
        /// </summary>
        public QueryConditionSigns Sign { get; private set; }
        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; private set; }

        public SqlQueryCondition(DBColumn col, QueryConditionSigns sign = QueryConditionSigns.Equals, string value = "")
        {
            Column = col;
            Sign = sign;
            Value = value;
        }

        public string ToString(StringBuilder sb)
        {
            return sb.AppendQueryCondition(this).ToString();
        }
        public override string ToString()
        {
            return ToString(new StringBuilder());
        }
    }
}
