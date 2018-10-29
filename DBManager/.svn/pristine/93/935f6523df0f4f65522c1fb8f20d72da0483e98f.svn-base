using DBManager.Gregorian.DTO;
using DBManager.TableColumns;

namespace DBManager.Gregorian.Tables
{
    /// <summary>
    /// Таблица Дат в БД
    /// </summary>
    public class DatesTable : TableTypes.SingleEtityTable_WithID<DatesTable, DBE_Date, int>
    {
        public const string tableName = "Dates";

        internal DatesTable(DBContext context) : base(context) { }

        protected override DBTableScheme<DatesTable, TableColumn<DatesTable, DBE_Date>, DBE_Date> CreateScheme()
        {
            var s = new DBTableScheme<DatesTable, TableColumn<DatesTable, DBE_Date>, DBE_Date>(tableName);
            s.AddColumn(new TC_IDInt32<DatesTable, DBE_Date>(this), 0);
            s.AddColumn(new TC_Byte<DatesTable, DBE_Date>(this, "DayOfWeekID"), 1);
            s.AddColumn(new TC_Byte<DatesTable, DBE_Date>(this, "MonthID"), 2);
            s.AddColumn(new TC_Byte<DatesTable, DBE_Date>(this, "MonthIndex"), 3);
            s.AddColumn(new TC_Byte<DatesTable, DBE_Date>(this, "SeasonID"), 4);
            s.AddColumn(new TC_Byte<DatesTable, DBE_Date>(this, "SeasonIndex"), 5);
            s.AddColumn(new TC_Int32<DatesTable, DBE_Date>(this, "YearID"), 6);
            s.AddColumn(new TC_SmallInt<DatesTable, DBE_Date>(this, "YearIndex"), 7);
            s.AddColumn(new TC_Date<DatesTable, DBE_Date>(this, "DateValue"), 8);

            return s;
        }
    }
}
