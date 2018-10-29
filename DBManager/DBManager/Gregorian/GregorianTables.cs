using DBManager.Gregorian.Tables;
using System.Collections.Generic;

namespace DBManager.Gregorian
{
    /// <summary>
    /// Таблицы в БД GregorianCalendar
    /// </summary>
    public class GregorianTables : DBTablesCollection
    {
        /// <summary>
        /// Таблица Стран
        /// </summary>
        public CountriesTable Countries { get { return (CountriesTable)base[CountriesTable.tableName]; } }

        /// <summary>
        /// Таблица Регионов
        /// </summary>
        public RegionsTable Regions { get { return (RegionsTable)base[RegionsTable.tableName]; } }

        /// <summary>
        /// Таблица Событий
        /// </summary>
        public EventsTable Events { get { return (EventsTable)base[EventsTable.tableName]; } }

        /// <summary>
        /// Таблица Дат
        /// </summary>
        public DatesTable Dates { get { return (DatesTable)base[DatesTable.tableName]; } }

        /// <summary>
        /// Таблица Рабочих дней
        /// </summary>
        public WorkingDaysTable WorkDays { get { return (WorkingDaysTable)base[WorkingDaysTable.tableName]; } }

        /// <summary>
        /// Таблица с Типами Рабочих дней
        /// </summary>
        public WorkingDayTypesTable WorkDayTypes { get { return (WorkingDayTypesTable)base[WorkingDayTypesTable.tableName]; } }

        internal GregorianTables(IEnumerable<DBTable> tables) : base(tables)
        {

        }
    }
}
