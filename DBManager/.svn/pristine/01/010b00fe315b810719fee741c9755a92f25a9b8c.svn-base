using CalendarManagment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBManager
{
    /// <summary>
    /// Общие процедуры
    /// </summary>
    static class CommonProcs
    {
        /// <summary>
        /// Получение информации о списке параметров для записи в лог
        /// </summary>
        /// <param name="_params">Список параметров</param>
        /// <returns>ВОзвращает список параметров логера</returns>
        public static List<MessageParameter> GetParametersInfo(params SqlParameter[] _params)
        {
            var listParams = new List<MessageParameter>(_params.Length + 1);

            var sb = new StringBuilder();
            for (int i = 0; i < _params.Length; i++)
                listParams.Add(GetParameterInfo(sb, _params[i]));
            return listParams;
        }

        public static MessageParameter GetConditionsInfo(params SqlQueryCondition[] conditions)
        {
            var result = new List<MessageParameter>();

            if (conditions == null || conditions.Length == 0)
                return null;

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < conditions.Length; i++)
            {
                sb.AppendQueryCondition(conditions[i]).Append("; ");
            }
            sb.Remove(sb.Length - 2, 2);

            return new MessageParameter("Условия Запроса", sb.ToString());
        }

        /// <summary>
        /// Единичное получение информации о Параметре для записи в Лог
        /// </summary>
        /// <param name="sb">Экземпляр StringBuilder для более быстрой конкатинации строковых значений</param>
        /// <param name="p">Параметр</param>
        /// <returns>ВОзвращает параметр для Логера</returns>
        internal static MessageParameter GetParameterInfo(StringBuilder sb, SqlParameter p)
        {
            sb.Clear();
            if (p == null)
                return new MessageParameter("Параметр", "Пустая ссылка на параметр!");

            return new MessageParameter("Параметр " + p.ParameterName,
                sb.Append("; Значение: ").Append(p.Value == null ? "null" : p.Value.ToString())
                    .Append("; Тип значения: ").Append(p.DbType.ToString())
                    .Append("; Размер: ").Append(p.Size.ToString())
                    .Append("; Разряд: ").Append(p.Scale.ToString())
                    .Append("; Направление: ").Append(p.Direction.ToString())
                    .ToString());
        }

        /// <summary>
        /// Более быстрое получение значения параметра с проверкой на null
        /// </summary>
        /// <typeparam name="TSql">Тип SQL-параметра</typeparam>
        /// <typeparam name="TValue">Тип Извлекаемого и возвращаемого значения</typeparam>
        /// <param name="p">Имя параметра</param>
        /// <returns>Возвращает значение параметра или значение по умолчаниб для указанного типа</returns>
        public static TValue GetSqlValue<TValue>(this SqlParameter p)
        {
            try
            {
                dynamic sqlVal = (System.Data.SqlTypes.INullable)p.SqlValue;

                if (sqlVal.IsNull)
                    return default(TValue);

                return (TValue)sqlVal.Value;
            }
            catch (System.Exception ex)
            {
                LogManager.WriteException("Возникло исключение при извлечении значения из Sql-параметра. Возвращено значение по умолчанию", ex,
                    new MessageParameter("Тип Sql-значения", p.SqlValue == null ? "NULL" : p.SqlValue.GetType().FullName)
                    , new MessageParameter("Тип значения", p.Value == null ? "NULL" : p.Value.GetType().FullName)
                    , new MessageParameter("Ожидаемый тип", typeof(TValue).FullName));

                return default(TValue);
            }
        }

        /// <summary>
        /// Добавляет имена колонок из указанной схемы к запросу
        /// </summary>
        /// <param name="sb">Экземпляр StringBuilder, для построекния запроса</param>
        /// <param name="columns">Колонки для вставки таблицы</param>
        /// <returns>Колонки таблицы</returns>
        public static StringBuilder AppendColumnNames(this StringBuilder sb, IEnumerable<DBColumn> columns)
        {
            foreach (DBColumn col in columns)
            {
                sb.Append(col.Name);
                sb.Append(", ");
            }

            return sb.Remove(sb.Length - 2, 2);
        }

        /// <summary>
        /// Добавление строкового представления Условия в SQL запрос
        /// </summary>
        /// <param name="sb">Текущий экземпляр StringBuider для построения запроса</param>
        /// <param name="col">Колонка</param>
        /// <param name="sign">Знак сравнения</param>
        /// <param name="value">Значение (NULL можно не указывать)</param>
        /// <returns>Возвращает переданный экземпляр с добавленным Условием</returns>
        public static StringBuilder AppendQueryCondition(this StringBuilder sb, SqlQueryCondition condition)
        {
            if (condition.Sign == QueryConditionSigns.UnKnown)
                return sb;

            sb.Append(" ").Append(condition.Column.Name);
            switch (condition.Sign)
            {
                case QueryConditionSigns.Equals:
                    return sb.Append(" = ").Append(condition.Value).Append(" ");
                case QueryConditionSigns.EqulsNULL:
                    return sb.Append(" IS NULL ");
                case QueryConditionSigns.LessOrEquals:
                    return sb.Append(" <= ").Append(condition.Value).Append(" ");
                case QueryConditionSigns.LessThan:
                    return sb.Append(" < ").Append(condition.Value).Append(" ");
                case QueryConditionSigns.NotEquals:
                    return sb.Append(" != ").Append(condition.Value).Append(" ");
                case QueryConditionSigns.MoreThan:
                    return sb.Append(" > ").Append(condition.Value).Append(" ");
                case QueryConditionSigns.NotEqualsNull:
                    return sb.Append(" IS NOT NULL ");
                case QueryConditionSigns.MoreOrEquals:
                    return sb.Append(" >= ").Append(condition.Value).Append(" ");
                default:
                    LogManager.WriteMessage("Условие для SQL-запроса сформировано не корректно - Не определён тип условия",
                        new MessageParameter("Имя колонки", condition.Column.Name)
                        , new MessageParameter("Тип Условия", condition.Sign.ToString())
                        , new MessageParameter("Сравниваемое значение", condition.Value));
                    return sb;
            }
        }

    }
}
