using DBManager.Gregorian.DTO;
using System;
using System.Data.SqlClient;
using System.Text;

namespace DBManager.Gregorian
{
    public class GregorianStaticQueriesCollection : DBStaticQueriesCollection
    {
        readonly DBContext _context;

        /// <summary>
        /// Получение информации о Рабочем дне
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="country">Страна</param>
        /// <param name="region">Регион</param>
        /// <returns>Возвращает данные по рабочему дню в БД или пустой экземпляр</returns>
        public DTO.Service.WorkingDateInfo GetDateInfo(DateTime date, DBE_Country country, DBE_Region region = null)
        {

            if (country == null)
                throw new ArgumentNullException("Запрос информации о Рабочем дне по пустой ссылке на СТрану не предусмотрен");

            SqlCommand com = null;
            SqlDataReader reader = null;

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT wd.WokingDayTypeID, d.DayOfWeekID, d.YearIndex FROM work.workingdays wd 
                            LEFT JOIN Dates d ON d.ID = wd.DateID
                            WHERE d.DateValue = ").Append(date.ToShortDateString())
                    .Append("AND wd.CountryID = ").Append(country.ID);


                com = new SqlCommand(sb.ToString());
                com.Connection = _context.OpenConnection();

                reader = com.ExecuteReader();
                if(!reader.HasRows)
                    return new DTO.Service.WorkingDateInfo(date, CalendarCore.Gregorian.WorkingDayType.UnKnown, 0, 0);

                reader.Read();

                return new DTO.Service.WorkingDateInfo(date, (CalendarCore.Gregorian.WorkingDayType)reader.GetFieldValue<int>(0), reader.GetFieldValue<int>(1), reader.GetFieldValue<int>(2));
            }
            catch(Exception ex)
            {
                CalendarManagment.LogManager.WriteException("Возникло исключение при запросе Рабочего дня", ex, 
                    new CalendarManagment.MessageParameter("Дата", date.ToShortDateString())
                    , new CalendarManagment.MessageParameter("Страна", country == null ? "NULL" : string.Concat(country.ID, " | ", country.CommonName))
                    , new CalendarManagment.MessageParameter("Регион", region == null ? "NULL" : string.Concat(region.ID, " | ", region.Name))
                    , new CalendarManagment.MessageParameter("Строка подключения", _context == null ? "NULL Context" : _context.ConnectionString));

                return new DTO.Service.WorkingDateInfo(date, CalendarCore.Gregorian.WorkingDayType.UnKnown, 0, 0);
            }
            finally
            {
                if(reader != null)
                {
                    if(!reader.IsClosed)
                        reader.Close();
                }
                if(com.Connection != null)
                {
                    com.Connection.Close();
                    com.Connection.Dispose();
                }

                if (com != null)
                    com.Dispose();
            }
        }

        public GregorianStaticQueriesCollection(DBContext context) : base(new DBStaticQuery[1])
        {
            if (context == null)
                throw new ArgumentNullException("Создание коллекции запросов по пустой ссылке на контекст не предусмотрено");

            _context = context;
        }
    }
}
