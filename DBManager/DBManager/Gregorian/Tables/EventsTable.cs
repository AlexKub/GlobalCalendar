using DBManager.Gregorian.DTO;
using DBManager.TableColumns;

namespace DBManager.Gregorian.Tables
{
    /// <summary>
    /// Представление Таблицы Событий в БД 
    /// </summary>
    public class EventsTable : TableTypes.SingleEtityTable_WithID<EventsTable, DBE_Event, int>
    {
        public const string tableName = "Events";

        internal EventsTable(DBContext context) : base(context) { }

        protected override DBTableScheme<EventsTable, TableColumn<EventsTable, DBE_Event>, DBE_Event> CreateScheme()
        {
            var s = new DBTableScheme<EventsTable, TableColumn<EventsTable, DBE_Event>, DBE_Event>(tableName);
            s.AddColumn(new TC_IDInt32<EventsTable, DBE_Event>(this), 0);
            s.AddColumn(new TC_NVChar<EventsTable, DBE_Event>(this, "RusName"), 1);

            return s;
        }
    }
}
