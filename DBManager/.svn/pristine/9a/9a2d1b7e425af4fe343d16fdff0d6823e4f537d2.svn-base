using System;
using System.Data.SqlClient;
using CalendarCore;
using DBManager.Gregorian.Tables;

namespace DBManager.Gregorian
{
    /// <summary>
    /// Контекст БД Грегорианского календаря
    /// </summary>
    public sealed class GregorianDBContext : DBContext
    {
        public GregorianDBContext(string connectionString = null)
            : base(connectionString == null ? "Data Source=79.120.10.135,55355;Initial Catalog=GregorianCalendar;Integrated Security=false;User id=Kamerton;password=kYl1ck_$;Connect Timeout=10;" : connectionString)
        {
            _staticQueries = new GregorianStaticQueriesCollection(this);

            Tables = new GregorianTables(
                new DBTable[] {
                    new CountriesTable(this)
                    , new RegionsTable(this)
                    , new EventsTable(this)
                    , new DatesTable(this)
                    , new WorkingDaysTable(this)
                    , new WorkingDayTypesTable(this)
                });
        }

        public DateInfo GetDateInfo(DateTime? date, string locale)
        {

            if (date == null)
                date = DateTime.Now;
            if (string.IsNullOrWhiteSpace(locale))
                locale = "ru-ru";

            SqlParameter dateP = CreateParameter("date", System.Data.SqlDbType.Date, date);

            SqlParameter localeP = CreateParameter("locale", System.Data.SqlDbType.NVarChar, locale);
            localeP.Size = 7;

            SqlParameter weekNameP = new SqlParameter();
            weekNameP.ParameterName = "weekName";
            weekNameP.Direction = System.Data.ParameterDirection.Output;
            weekNameP.SqlDbType = System.Data.SqlDbType.NVarChar;
            weekNameP.Size = 50;

            SqlParameter seasonNameP = new SqlParameter();
            seasonNameP.ParameterName = "seasonName";
            seasonNameP.Direction = System.Data.ParameterDirection.Output;
            seasonNameP.SqlDbType = System.Data.SqlDbType.NVarChar;
            seasonNameP.Size = 50;

            SqlParameter monthNameP = new SqlParameter();
            monthNameP.ParameterName = "monthName";
            monthNameP.Direction = System.Data.ParameterDirection.Output;
            monthNameP.SqlDbType = System.Data.SqlDbType.NVarChar;
            monthNameP.Size = 50;

            SqlParameter weekIndexP = new SqlParameter();
            weekIndexP.ParameterName = "weekIndex";
            weekIndexP.Direction = System.Data.ParameterDirection.Output;
            weekIndexP.SqlDbType = System.Data.SqlDbType.TinyInt;

            SqlParameter seasonIndexP = new SqlParameter();
            seasonIndexP.ParameterName = "seasonIndex";
            seasonIndexP.Direction = System.Data.ParameterDirection.Output;
            seasonIndexP.SqlDbType = System.Data.SqlDbType.TinyInt;

            SqlParameter yearIndexP = new SqlParameter();
            yearIndexP.ParameterName = "yearIndex";
            yearIndexP.Direction = System.Data.ParameterDirection.Output;
            yearIndexP.SqlDbType = System.Data.SqlDbType.SmallInt;

            ExecProc("sp_getDateInfo", dateP, localeP, weekNameP, seasonNameP, monthNameP, weekIndexP, seasonIndexP, yearIndexP);

            return new DateInfo()
            {
                WeekDayName = weekNameP.GetSqlValue<string>(),
                SeasonName = seasonNameP.GetSqlValue<string>(),
                MonthName = monthNameP.GetSqlValue<string>(),
                WeekIndex = weekIndexP.GetSqlValue<byte>(),
                SeasonIndex = seasonIndexP.GetSqlValue<byte>(),
                YearIndex = yearIndexP.GetSqlValue<UInt16>()
            };
        }

        /// <summary>
        /// Таблицы БД
        /// </summary>
        public GregorianTables Tables { get; private set; }

        readonly GregorianStaticQueriesCollection _staticQueries;

        /// <summary>
        /// Статичные запросы к БД
        /// </summary>
        public GregorianStaticQueriesCollection StaticQueries { get { return _staticQueries; } }

    }
}
