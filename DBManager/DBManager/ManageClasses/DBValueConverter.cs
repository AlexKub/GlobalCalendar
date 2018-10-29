using System;
using System.Linq;

namespace DBManager
{
    /// <summary>
    /// Конвертор значения из БД
    /// </summary>
    public class DBValueConverter<TSqlClient, TValue> 
        where TSqlClient : System.Data.SqlTypes.INullable
    {
        static readonly DBValueConverter<TSqlClient, TValue> _instance = new DBValueConverter<TSqlClient, TValue>();

        /// <summary>
        /// Уникальный экземпляр Конвертера
        /// </summary>
        public static DBValueConverter<TSqlClient, TValue> Instance { get { return _instance; } }

        private DBValueConverter() { }

        /// <summary>
        /// Привидение значения к ожидаемому типу
        /// </summary>
        /// <param name="obj">Приводимое значение</param>
        /// <returns>Возвращает ожидаемое значение</returns>
        /// <exception cref="InvalidCastException">При исключении на конвертации</exception>
        internal TValue Convert(object obj)
        {
            if (obj == null)
                return default(TValue);

            try
            {
                return (TValue)obj;
            }
            catch(Exception ex)
            {
                CalendarManagment.LogManager.WriteException("Возникло исключение при конвертации Sql-значения", ex
                    , new CalendarManagment.MessageParameter("Имя типа входящего значения", obj == null ? "NULL" : obj.GetType().FullName)
                    , new CalendarManagment.MessageParameter("Строковое представление входящего значения", obj == null ? "NULL" : obj.ToString())
                    , new CalendarManagment.MessageParameter("Имя типа Значения", typeof(TValue).FullName));

                throw new InvalidCastException("Исключение при конвертации параметра", ex);
            }
        }

        /// <summary>
        /// Приведение значения параметра к желаемому типу
        /// </summary>
        /// <param name="p">Параметр</param>
        /// <returns>Возвращает ожедаемый тип значения Конвертатора</returns>
        /// <exception cref="InvalidCastException">При исключении на конвертации</exception>
        internal TValue Convert(System.Data.SqlClient.SqlParameter p) 
        {
            try
            {
                dynamic sqlVal = (TSqlClient)p.SqlValue;
            
                if (sqlVal.IsNull)
                    return default(TValue);


                return (TValue)sqlVal.Value;
            }
            catch(Exception ex)
            {
                CalendarManagment.LogManager.WriteException("Возникло исключение при конвертации Sql-параметра", ex
                    , new CalendarManagment.MessageParameter("Имя параметра", p == null ? "NULL REFERENCE" : p.ParameterName)
                    , new CalendarManagment.MessageParameter("Имя SqlClinet типа", typeof(TSqlClient).FullName)
                    , new CalendarManagment.MessageParameter("Имя типа Значения", typeof(TValue).FullName));

                throw new InvalidCastException("Исключение при конвертации параметра", ex);
            }
        }
    }
}
